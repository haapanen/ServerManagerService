using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Jose;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Server.Kestrel;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using JWT = ServerManagerService.Models.JWT;

namespace ServerManagerService.Filters
{
    public class AuthenticationFilter : IActionFilter
    {
        private readonly IConfiguration _configuration;

        public AuthenticationFilter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Request.Headers.ContainsKey("Bearer"))
            {
                context.Result = new BadRequestObjectResult("Bearer token is missing.");
                return;
            }

            var bearer = context.HttpContext.Request.Headers["Bearer"];
            var key = Encoding.UTF8.GetBytes(_configuration.GetSection("Key").Value);

            try
            {
                var decodedData = Jose.JWT.Decode(bearer, key);

                var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(decodedData);

                var jwt = new JWT
                {
                    Issuer = dict["iss"],
                    Audience = dict["aud"],
                    Expiration = DateTimeOffset.FromUnixTimeSeconds(int.Parse(dict["exp"])).UtcDateTime,
                    IssuetAt = DateTimeOffset.FromUnixTimeSeconds(int.Parse(dict["iat"])).UtcDateTime,
                    Subject = dict["sub"]
                };

                if (jwt.Expiration < DateTime.UtcNow)
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }

                (context.HttpContext.User.Identity as ClaimsIdentity)?.AddClaim(new Claim(ClaimTypes.GivenName, jwt.Subject));
            }
            catch (Exception e)
            {
                context.Result = new UnauthorizedResult();
                return;
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
    }
}

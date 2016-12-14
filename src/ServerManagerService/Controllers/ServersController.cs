using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetMQ;
using NetMQ.Sockets;
using Newtonsoft.Json;
using ServerManagerService.DbContexts;
using ServerManagerService.Filters;
using ServerManagerService.Models;

namespace ServerManagerService.Controllers
{
    [Route("api/servers")]
    public class ServersController : Controller
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly PermissionsContext _permissionsContext;

        public ServersController(IHttpContextAccessor httpContext, PermissionsContext permissionsContext)
        {
            _httpContext = httpContext;
            _permissionsContext = permissionsContext;
        }

        private string GetGivenName()
        {
            return
                (_httpContext.HttpContext.User.Identity as ClaimsIdentity)?.Claims.SingleOrDefault(
                    x => x.Type == ClaimTypes.GivenName)?.Value;
        }

        [HttpPost("actions")]
        [Produces(typeof(string))]
        public IActionResult CreateAction([FromBody]ServerAction action)
        {
            var name = GetGivenName();
            var permissions = _permissionsContext.Permissions.Where(x => x.Name == name);

            if (!permissions.Any(x => x.Name == action.Target))
            {
                return Unauthorized();
            }

            using (var requestSocket = new RequestSocket(">tcp://localhost:33999"))
            {
                IMessage message;
                switch (action.Type)
                {
                    case ActionType.Start:
                        message = new StartServerCommand();
                        break;
                    case ActionType.Stop:
                        break;
                    case ActionType.Restart:
                        break;
                    case ActionType.None:
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                requestSocket.SendFrame(JsonConvert.SerializeObject(new ));
            }

            return Ok();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NetMQ;
using NetMQ.Sockets;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ServerManagerService.DbContexts;
using ServerManagerService.Filters;
using ServerManagerService.Models;
using ServiceContracts;
using ServiceContracts.Interfaces;


namespace ServerManagerService.Controllers
{
    [Route("api/servers")]
    public class ServersController : Controller
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly PermissionsContext _permissionsContext;
        private readonly string _zmqUrl;

        public ServersController(IHttpContextAccessor httpContext, PermissionsContext permissionsContext, IConfiguration configuration)
        {
            _httpContext = httpContext;
            _permissionsContext = permissionsContext;
            _zmqUrl = configuration.GetSection("ZeroMQUrl").Value;
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

            if (!permissions.Any(x => x.Target == action.Target))
            {
                return Unauthorized();
            }

            Console.WriteLine("Opening a request socket to " + _zmqUrl);
            using (var requestSocket = new RequestSocket(">" + _zmqUrl))
            {
                switch (action.Type)
                {
                    case ActionType.Start:
                        requestSocket.SendFrame(JsonConvert.SerializeObject(new Message<IStartServerCommand>(MessageType.Command, new StartServerCommand(action.Target)), new JsonSerializerSettings
                        {
                            ContractResolver = new CamelCasePropertyNamesContractResolver()
                        }));
                        return Ok(requestSocket.ReceiveFrameString());
                        break;
                    case ActionType.Stop:
                        requestSocket.SendFrame(JsonConvert.SerializeObject(new Message<IStopServerCommand>(MessageType.Command, new StopServerCommand(action.Target)), new JsonSerializerSettings
                        {
                            ContractResolver = new CamelCasePropertyNamesContractResolver()
                        }));
                        return Ok(requestSocket.ReceiveFrameString());
                        break;
                    case ActionType.Restart:
                        requestSocket.SendFrame(JsonConvert.SerializeObject(new Message<IRestartServerCommand>(MessageType.Command, new RestartServerCommand(action.Target)), new JsonSerializerSettings
                        {
                            ContractResolver = new CamelCasePropertyNamesContractResolver()
                        }));
                        return Ok(requestSocket.ReceiveFrameString());
                        break;
                    case ActionType.None:
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return Ok();
        }
    }
}

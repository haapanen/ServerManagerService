using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetMQ;
using NetMQ.Sockets;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ServiceContracts;

namespace ZmqEndpointMock
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting the application");
            using (var responseSocket = new ResponseSocket("@tcp://*:42424"))
            {
                while (true)
                {
                    var frame = responseSocket.ReceiveFrameString();
                    var message = JsonConvert.DeserializeObject(frame, new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    });
                    responseSocket.SendFrameEmpty();
                    
                    Console.WriteLine(frame);
                }
            }
        }
    }
}

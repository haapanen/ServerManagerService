using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServerManagerService.Models
{
    public enum ActionType
    {
        None,
        Start,
        Stop,
        Restart
    }

    public class ServerAction
    {
        [Required]
        public string Target { get; set; }
        [Required]
        public ActionType Type { get; set; }
    }
}

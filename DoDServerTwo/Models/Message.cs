using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DoDServerTwo.Models
{
    public class Message
    {

        public int Id { get; set; }

        public string Mess { get; set; }

        public string Username { get; set; }

        public string Userstatus { get; set; }

        public string UserId { get; set; }

        public string Time { get; set; }
    }
}

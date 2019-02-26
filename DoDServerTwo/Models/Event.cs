using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoDServerTwo.Models
{
    public class Event
    {
        public int Id { get; set; }

        public string Place { get; set; }

        public int Duration { get; set; }

        public DateTime Time { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public byte[] SpeakerImage { get; set; }

        public string SpeakerName { get; set; }

        public string Info { get; set; }

        public string EventColor { get; set; }
    }
}

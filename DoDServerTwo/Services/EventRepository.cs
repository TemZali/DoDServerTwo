using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoDServerTwo.Models;
using DoDServerTwo.Interfaces;

namespace DoDServerTwo.Services
{
    public class EventRepository : IEventRepository
    {
        List<Event> events;
        public List<Event> All
        {
            get
            {
                return events;
            }
        }

        public void Insert(Event ev)
        {
            events.Add(ev);
        }

        public void Delete(string id)
        {
            foreach(Event ev in events)
            {
                if (ev.Id.ToString() == id)
                {
                    events.Remove(ev);
                }
            }
        }
    }
}

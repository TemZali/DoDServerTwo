using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoDServerTwo.Models;

namespace DoDServerTwo.Interfaces
{
    public interface IEventRepository
    {
        List<Event> All { get; }
        void Insert(Event ev);
        void Delete(string id);
    }
}

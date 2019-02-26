using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoDServerTwo.Models;

namespace DoDServerTwo.Interfaces
{
    public interface IMessageRepository
    {
        bool DoesMessageExist(string id);
        List<Message> All { get; }
        List<Message> AllFromIndex(int index);
        Message Find(string id);
        Message FindLast();
        void Insert(Message item);
        void Update(Message item);
        void Delete(string id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoDServerTwo.Models;
using DoDServerTwo.Interfaces;

namespace DoDServerTwo.Services
{
    public class MessageRepository : IMessageRepository
    {
        List<Message> messages;

        public MessageRepository()
        {
            messages = new List<Message>();
        }

        public List<Message> All
        {
            get
            {
                return messages;
            }
        }

        public void Delete(string id)
        {
            foreach(Message mess in messages)
            {
                if (mess.Id.ToString() == id)
                {
                    messages.Remove(mess);
                }
            }
        }

        public List<Message> AllFromIndex(int index)
        {
            List<Message> lst = new List<Message>();
            for(int i = index - 1; i < All.Count; i++)
            {
                lst.Add(All[i]);
            }
            return lst;
        }

        public bool DoesMessageExist(string id)
        {
            foreach (Message mess in messages)
            {
                if (mess.Id.ToString() == id)
                {
                    return true;
                }
            }
            return false;
        }

        public Message FindLast()
        {
            return messages.Last();
        }

        public Message Find(string id)
        {
            foreach (Message mess in messages)
            {
                if (mess.Id.ToString() == id)
                {
                    return mess;
                }
            }
            return null;
        }

        public void Insert(Message item)
        {
            item.Id = messages.Count+1;
            messages.Add(item);
        }

        public void Update(Message item)
        {
            foreach (Message mess in messages)
            {
                if (mess.Id == item.Id)
                {
                    messages.Remove(mess);
                    messages.Add(item);
                }
            }
        }
    }
}

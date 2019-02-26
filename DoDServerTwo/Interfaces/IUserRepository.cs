using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoDServerTwo.Models;

namespace DoDServerTwo.Interfaces
{
    public interface IUserRepository
    {
        bool DoesUserExist(string id);
        int Insert(User user);
        void Delete(string id);
        User FindLast();
        List<User> All();
        int FindByName(string name);
        int GetCount();
    }
}

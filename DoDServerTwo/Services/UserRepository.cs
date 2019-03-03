using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoDServerTwo.Models;
using DoDServerTwo.Interfaces;

namespace DoDServerTwo.Services
{
    public class UserRepository : IUserRepository
    {
        List<User> users;

        public List<User> All()
        {
            return users;
        }

        public User IsPasswordRight(string username_password)
        {
            string[] info = username_password.Split();
            foreach(User user in users)
            {
                if (user.Username == info[0])
                {
                    if (user.Userpassword == info[1])
                    {
                        return user;
                    }
                    return null;
                }
            }
            return null;
        }

        public int GetCount()
        {
            return users.Count;
        }

        public UserRepository()
        {
            users = new List<User>();
        }

        public User FindLast()
        {
            return users.Last();
        }

        public int FindByName(string name)
        {
            for (int i = users.Count - 1; i >= 0; i--)
            {
                if (users[i].Username == name)
                    return users[i].Id;
            }
            return -1;
        }

        public void Delete(string id)
        {
            foreach (User user in users)
            {
                if (user.Id.ToString() == id)
                {
                    users.Remove(user);
                }
            }
        }

        public bool DoesUserExist(string id)
        {
            foreach (User user in users)
            {
                if (user.Id.ToString() == id)
                {
                    return true;
                }
            }
            return false;
        }

        public int Insert(User newUser)
        {
            foreach (User user in users)
            {
                if (user.Username == newUser.Username)
                    return -1;
            }
            users.Add(newUser);
            return newUser.Id;
        }
    }
}

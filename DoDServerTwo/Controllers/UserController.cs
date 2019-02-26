using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using DoDServerTwo.Models;
using DoDServerTwo.Interfaces;
using DoDServerTwo.Services;


namespace DoDServerTwo.Controllers
{
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository UserRepository)
        {
            userRepository = UserRepository;
        }

        [HttpGet]
        public List<User> GetAll()
        {
            return userRepository.All();
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            if (userRepository.DoesUserExist(id))
            {
                return CreatedAtAction("OK", true);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public int Post([FromBody]User user)
        {
            try
            {
                if (user == null || !ModelState.IsValid)
                {
                    return -1;
                }
                user.Id = userRepository.GetCount();
                return userRepository.Insert(user);
            }
            catch (Exception)
            {
                return -1;
            }
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            userRepository.Delete(id);
        }

    }
}

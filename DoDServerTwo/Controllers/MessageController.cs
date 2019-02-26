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
    [Route("api/message")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageRepository messageRepository;

        public MessageController(IMessageRepository MessageRepository)
        {
            messageRepository = MessageRepository;
        }

        [HttpGet]
        public ActionResult<Message> GetMessages()
        {
            return messageRepository.FindLast();
        }

        [HttpGet("{id}")]
        public ActionResult<List<Message>> GetMessagesFromIndex(int id)
        {
            if (id > 1)
                return messageRepository.AllFromIndex(id);
            return messageRepository.All;
        }

        public enum ErrorCode
        {
            TodoItemNameAndNotesRequired,
            TodoItemIDInUse,
            RecordNotFound,
            CouldNotCreateItem,
            CouldNotUpdateItem,
            CouldNotDeleteItem
        }


        [HttpPost]
        public IActionResult Post([FromBody] Message message)
        {

            try
            {
                if (message == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.TodoItemNameAndNotesRequired.ToString());
                }
                messageRepository.Insert(message);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotCreateItem.ToString());
            }

            return CreatedAtAction(nameof(GetMessages), new { id = message.Id }, message);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Message message)
        {
            messageRepository.Update(message);

            return CreatedAtAction(nameof(GetMessages), new { id = message.Id }, message);
        }

    }
}
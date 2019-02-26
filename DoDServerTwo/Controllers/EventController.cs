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
    [Route("api/event")]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository eventRepository;

        public EventController(IEventRepository EventRepository)
        {
            eventRepository = EventRepository;
        }

        [HttpGet]
        public List<Event> Get()
        {
            return eventRepository.All;
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
        public IActionResult Post([FromBody] Event ev)
        {
            try
            {
                if (ev == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.TodoItemNameAndNotesRequired.ToString());
                }
                eventRepository.Insert(ev);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotCreateItem.ToString());
            }

            return CreatedAtAction(nameof(eventRepository.All), new { id = ev.Id }, ev);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            eventRepository.Delete(id);
        }
    }
}

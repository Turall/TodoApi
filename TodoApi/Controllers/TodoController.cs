using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
       
        public TodoController(ITodoRepository todoItems)
        {
            TodoItems = todoItems;
        }

        public ITodoRepository TodoItems { get; set; }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            return TodoItems.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}",Name ="GetTodo")]
        public IActionResult GetById(string id)
        {
            var item = TodoItems.Find(id);
            if(item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Create([FromBody]TodoItem item)
        {
            if(item == null)
            {
                return BadRequest();
            }
            TodoItems.Add(item);
            return CreatedAtRoute("GetTodo", new { id = item.Key }, item);
        }

        // PUT api/<controller>/5
        [HttpPatch("{id}")]
        public IActionResult Update([FromBody]TodoItem item,string id)
        {
            if(item == null)
            {
                return BadRequest();
            }
            var todo = TodoItems.Find(id);
            if(todo == null)
            {
                return NotFound();
            }
            item.Key = todo.Key;
            TodoItems.Update(item);
            return new NoContentResult();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var todo = TodoItems.Find(id);
            if(todo == null)
            {
                return NotFound();
            }
            TodoItems.Remove(id);
            return new NoContentResult();
        }
    }
}

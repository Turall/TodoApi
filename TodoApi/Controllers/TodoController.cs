using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;
using Microsoft.AspNetCore.Mvc;



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

       
        [HttpGet("GetAll")]
        public IEnumerable<StatusInfo> GetAll()
        {
            return TodoItems.GetAll();
        }

        
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

       
        [HttpPost("Create")]
        public IActionResult Create([FromBody]StatusInfo item)
        {
            if(item == null)
            {
                return BadRequest();
            }
            TodoItems.Add(item);
            return CreatedAtRoute("GetTodo", new { id = item.Key }, item);
        }

        
        [HttpPatch("{id}")]
        public IActionResult Update([FromBody]StatusInfo item,string id)
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

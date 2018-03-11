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
        private readonly TodoContex _contex;
        public TodoController(TodoContex contex)
        {
            _contex = contex;
            if(_contex.TodoItems.Count() == 0)
            {
                _contex.TodoItems.Add(new TodoItem { Name = "item1" });
                _contex.SaveChanges();
            }
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            return _contex.TodoItems.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}",Name ="GetTodo")]
        public IActionResult GetById(long id)
        {
            var item = _contex.TodoItems.FirstOrDefault(t => t.Id == id);
            if(item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

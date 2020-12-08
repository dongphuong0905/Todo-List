using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using Microsoft.EntityFrameworkCore;

namespace ToDoList.Controllers
{
    [Route("todo")]
    [ApiController]
    public class TDController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Todo> GetAll()
        {
            using (var context = new entContext())
            {
                return context.Todos.ToList();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Todo> GetTodo(int id)
        {
            using (var context = new entContext())
            {
                return context.Todos.Find(id);
            }
        }

        [HttpPost("{value}")]
        public ActionResult<Todo> AddTodo(string value)
        {
            string dateTime = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
            Todo td = new Todo();
            td.TodoCreateTime = dateTime;
            td.TodoValue = value;
            td.TodoStatus = "1";
            using (var context = new entContext())
            {
                context.Todos.Add(td);
                context.SaveChanges();
                return NoContent();
            }

        }

        [HttpPost("modify/{id}/{value}")]
        public ActionResult<Todo> ModifyValue(int id, string value)
        {
            using (var context = new entContext())
            {
                var todo = context.Todos.Find(id);
                todo.TodoValue = value;
                context.Entry(todo).State = EntityState.Modified;
                try
                {
                    context.SaveChanges();
                    return NoContent();
                }
                catch (Exception e)
                {
                    return NotFound();
                }
            }
        }

        [HttpPost("status/{id}/{status}")]
        public ActionResult<Todo> ChangeStatus(int id, string status)
        {
            using (var context = new entContext())
            {
                var todo = context.Todos.Find(id);
                todo.TodoStatus = status;
                context.Entry(todo).State = EntityState.Modified;
                try
                {
                    context.SaveChanges();
                    return NoContent();
                }
                catch (Exception e)
                {
                    return NotFound();
                }
            }
        }

        [HttpDelete("delete/{id}")]
        public ActionResult<Todo> DeleteTodo(int id)
        {

            using (var context = new entContext())
            {
                var todo = context.Todos.Find(id);
                if (todo == null)
                {
                    return NotFound();
                }
                context.Todos.Remove(todo);
                context.SaveChanges();
                return NoContent();
            }
        }
    }
}
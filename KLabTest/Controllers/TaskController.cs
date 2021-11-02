using KLabTest.Models;
using KLabTest.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KLabTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TaskController : ControllerBase
    {
        private TaskService _taskService;

        public TaskController(TaskService taskService)
        {
            _taskService = taskService;

        }

        // GET: api/<TaskController>
        [HttpGet]
        public List<Models.Task> Get()
        {
            return _taskService.GetTaskList();
        }

        // POST api/<TaskController>
        [HttpPost]
        public void Post([FromBody] Models.Task task)
        {
            _taskService.AddTask(task);
        }

        // DELETE api/<TaskController>/5
        [HttpPost]
        [Route("Delete")]
        public void Delete(List<Models.Task> tasks)
        {
            _taskService.Delete(tasks);
        }
    }
}

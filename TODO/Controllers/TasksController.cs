using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TODO.Services.Contracts;
using TODO.Utilities.DTOs;

namespace TODO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService taskService;
        private readonly IMapper mapper;

        public TasksController(ITaskService taskService, IMapper mapper)
        {
            this.taskService = taskService;
            this.mapper = mapper;
        }

        // GET: api/Tasks
        [HttpGet]
        public async Task<ActionResult<ICollection<TaskDto>>> GetTasks()
        {
            var result = await this.taskService.GetTasks();
            return result.ToList();
        }

        // GET: api/Tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDto>> GetTask(int id)
        {
            return await this.taskService.GetTaskById(id);
        }

        // POST: api/Tasks/5/true
        [HttpPost("{id}/{status}")]
        public async Task<ActionResult<bool>> ChangeStatus(int id, bool status)
        {
            return await this.taskService.ChangeStatus(id,status);
        }

        // POST: api/Tasks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TaskDto>> AddTask(Domains.Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await this.taskService.AddTask(task);

            return this.mapper.Map<TaskDto>(task);
        }

        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteTask(int id)
        {
            return await this.taskService.DeleteTask(id);
        }

    }
}

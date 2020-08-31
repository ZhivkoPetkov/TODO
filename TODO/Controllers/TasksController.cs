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
        private readonly ICategoryService categoryService;

        public TasksController(ITaskService taskService, IMapper mapper, ICategoryService categoryService)
        {
            this.taskService = taskService;
            this.mapper = mapper;
            this.categoryService = categoryService;
        }

        // GET: api/Tasks
        [HttpGet]
        public async Task<ActionResult<ICollection<TaskDto>>> GetTasks()
        {
            var result = await this.taskService.GetTasks();
            return result.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDto>> GetTask(int id)
        {
            return await this.taskService.GetTaskById(id);
        }

        [HttpPost("finish/{id}")]
        public async Task<ActionResult<TaskDto>> ChangeStatus(int id)
        {
            return await this.taskService.ChangeStatus(id, true);
        }

        [HttpPost]
        public async Task<ActionResult<TaskDto>> AddTask(Domains.Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = await this.taskService.AddTask(task);
            var model = await this.taskService.GetTaskById(response);
            return this.mapper.Map<TaskDto>(model);
        }

        [HttpPatch("update")]
        public async Task<ActionResult<TaskDto>> UpdateTask(Domains.Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = await this.taskService.UpdateTask(task);
            var model = await this.taskService.GetTaskById(response.Id);
            return this.mapper.Map<TaskDto>(model);
        }

        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteTask(int id)
        {
            return await this.taskService.DeleteTask(id);
        }

    }
}

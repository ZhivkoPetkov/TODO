using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TODO.Domains;
using TODO.Domains.Data;
using TODO.Services.Contracts;
using TODO.Utilities.DTOs;

namespace TODO.Services
{
    public class TaskService : ITaskService
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext dbContext;
        private readonly ICategoryService categoryService;

        public TaskService(IMapper mapper, ApplicationDbContext dbContext, ICategoryService categoryService)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
            this.categoryService = categoryService;
        }

        public async Task<int> AddTask(Domains.Task newTask)
        {
            this.dbContext.Tasks.Add(newTask);
            this.dbContext.SaveChanges();

            return newTask.Id;
        }

        public async Task<bool> ChangeStatus(int id, bool status)
        {
            var task = this.dbContext.Tasks.Find(id);

            if (task is null)
            {
                return false;
            }

            task.IsFinished = status;
            this.dbContext.SaveChanges();

            return true;
        }

        public async Task<bool> DeleteTask(int id)
        {
            var task = this.dbContext.Tasks.Find(id);

            if (task is null)
            {
                return false;
            }

            this.dbContext.Tasks.Remove(task);
            this.dbContext.SaveChanges();

            return true;
        }

        public async Task<TaskDto> GetTaskById(int id)
        {
            var task = await this.dbContext.Tasks.Include(p => p.Category).FirstOrDefaultAsync(x => x.Id == id);
            return this.mapper.Map<TaskDto>(task);
        }

        public async Task<ICollection<TaskDto>> GetTasks()
        {
            return this.mapper.Map<List<TaskDto>>(this.dbContext.Tasks.ToList());
        }

        public async Task<TaskDto> UpdateTask(Domains.Task task)
        {
            this.dbContext.Tasks.Update(task);
            this.dbContext.SaveChanges();

            return this.mapper.Map<TaskDto>(task);
        }
    }
}

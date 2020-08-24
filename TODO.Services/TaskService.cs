using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TODO.Domains.Data;
using TODO.Services.Contracts;
using TODO.Utilities.DTOs;

namespace TODO.Services
{
    public class TaskService : ITaskService
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext dbContext;

        public TaskService(IMapper mapper, ApplicationDbContext dbContext)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }

        public async Task<int> AddTask(Domains.Task task)
        {
            this.dbContext.Tasks.Add(task);
            this.dbContext.SaveChanges();

            return task.Id;
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

            return true;
        }

        public async Task<TaskDto> GetTaskById(int id)
        {
            return this.mapper.Map<TaskDto>(this.dbContext.Tasks.Find(id));
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

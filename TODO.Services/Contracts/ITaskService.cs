using System.Collections.Generic;
using System.Threading.Tasks;
using TODO.Utilities.DTOs;

namespace TODO.Services.Contracts
{
    public  interface ITaskService
    {
        Task<TaskDto> GetTaskById(int id);
        Task<ICollection<TaskDto>> GetTasks();
        Task<int> AddTask(Domains.Task task);
        Task<TaskDto> UpdateTask(Domains.Task task);
        Task<bool> DeleteTask(int id);
        Task<TaskDto> ChangeStatus(int id, bool status);
    }
}

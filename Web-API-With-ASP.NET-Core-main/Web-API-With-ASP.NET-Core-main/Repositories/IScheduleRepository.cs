using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookAPI.Models;

namespace BookAPI.Repositories
{
    public interface IScheduleRepository
    {
         Task<IEnumerable<Schedule>> Get();
        Task<Schedule> Get(int id);
        Task<Schedule> Create(Schedule sh);
         Task Update(Schedule sh);
        Task Delete(int id, int userId, string day, string time, string job);
        

    }
}

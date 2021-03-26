using BookAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BookAPI.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private  readonly ScheduleContext _context;
        public ScheduleRepository(ScheduleContext context)
        {
            _context = context;
        }
        public async Task<Schedule> Create(Schedule sh)
        {
            _context.Schedules.Add(sh);
            await _context.SaveChangesAsync();
            return  sh;

        }

        public async Task Delete(int id, int userId, string day, string time, string job)
        {
            var shRemove = await _context.Schedules.FindAsync(id, userId, day, time, job);
            _context.Schedules.Remove(shRemove);
            await _context.SaveChangesAsync();
        }

        
        public async Task<IEnumerable<Schedule>> Get()
        {
            return await _context.Schedules.ToListAsync();
        }


        public async Task<Schedule> Get(int id)
        {
            return await _context.Schedules.FindAsync(id);
        }

        public Task Update(Schedule sh)
        {
            throw new NotImplementedException();
        }
    }
}

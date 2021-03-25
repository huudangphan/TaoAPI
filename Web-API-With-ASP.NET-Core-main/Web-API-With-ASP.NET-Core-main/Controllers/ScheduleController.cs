using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookAPI.Repositories;
using BookAPI.Models;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleRepository _scheduleRepository;
        public ScheduleController(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }
       
       
       

        [HttpGet]
        public async Task<IEnumerable<Schedule>> GetSchedule()
        {
            return await _scheduleRepository.Get();
        }
        [HttpGet("{id}")]
        public async Task<Schedule>GetSchedule(int id)
        {
            return await _scheduleRepository.Get(id);
        }
        [HttpPost]
        public async Task<ActionResult<Schedule>> PostSchedule([FromBody]Schedule sh)
        {
            var newSchedule = await _scheduleRepository.Create(sh);
            return CreatedAtAction(nameof(GetSchedule), new { id = sh.Id, userId = sh.UserID, day = sh.day, hourse = sh.hourse, job = sh.job }, newSchedule);
        }
        [HttpPut]
      
        public async Task<ActionResult> PutSchedule(int id,int userID,string day,string hourse,string job,[FromBody]Schedule sh)
        {
            if (id != sh.Id)
                return BadRequest();
            await _scheduleRepository.Update(sh);
            return NoContent();
        }
        [HttpDelete("{id}/{userID}/{day}/{hourse}/{job}")]

       
        public async Task<ActionResult>Delete(int id,int userID,string day,string hourse,string job)
        {
            var shDelete = await _scheduleRepository.Get(id);
            if (shDelete == null)
                return NotFound();
            await _scheduleRepository.Delete(shDelete.Id, shDelete.UserID, shDelete.day, shDelete.hourse, shDelete.job);
            return NoContent();
        }


    }
}

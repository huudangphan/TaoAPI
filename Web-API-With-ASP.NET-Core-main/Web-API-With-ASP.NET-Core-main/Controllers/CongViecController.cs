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
    public class CongViecController : ControllerBase
    {
        private readonly ICongViecRepository _congViecRepository;
        public CongViecController(ICongViecRepository congViecRepository)
        {
            _congViecRepository = congViecRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<CongViec>> GetCongViec()

        {
            return await _congViecRepository.Get();
        }
        [HttpGet("{user_id}")]
        public ActionResult<List<CongViec>> GetCongViec(int user_id)
        {
            return _congViecRepository.Get(user_id);
        }
        [HttpGet("{user_id}/{day}/{time}")]
        public ActionResult<List<CongViec>> GetCongViec(int user_id,string day,string time)
        {
            return _congViecRepository.Get(user_id,day,time);
        }
        [HttpGet("{user_id}/{day}")]
        public ActionResult<List<CongViec>> GetCongViec(int user_id, string day)
        {
            return _congViecRepository.Get(user_id, day);
        }
        [HttpPost]
        public async Task<ActionResult<CongViec>> PostCongViec([FromBody] CongViec cv)
        {
            var newCv = await _congViecRepository.Create(cv);
            return CreatedAtAction(nameof(GetCongViec), new { id = cv.Id,user_id=cv.user_id,day=cv.Day,thoigian=cv.ThoiGian }, newCv);
        }
        [HttpPut]
        public async Task<ActionResult> PutCongViec(int id, [FromBody] CongViec cv)
        {
            if (id != cv.Id)
            {
                return BadRequest();
            }

            await _congViecRepository.Update(cv);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var cvToDelete = GetCongViec(id);
            if (cvToDelete == null)
                return NotFound();

            await _congViecRepository.Delete(id);
            return NoContent();
        }
    }
}

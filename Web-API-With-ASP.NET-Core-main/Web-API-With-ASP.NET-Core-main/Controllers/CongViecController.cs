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
        [HttpGet("{id}/{user_id}/{day}/{thoigian}")]
        public async Task<ActionResult<CongViec>> GetCongViec(int id,int user_id,string day,string thoigian)
        {
            return await _congViecRepository.Get(id,user_id,day,thoigian);
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
        public async Task<ActionResult> Delete(int id,int user_id,string day,string thoigian)
        {
            var cvToDelete = await _congViecRepository.Get(id,user_id,day,thoigian);
            if (cvToDelete == null)
                return NotFound();

            await _congViecRepository.Delete(cvToDelete.Id,cvToDelete.user_id,cvToDelete.Day,cvToDelete.ThoiGian);
            return NoContent();
        }
    }
}

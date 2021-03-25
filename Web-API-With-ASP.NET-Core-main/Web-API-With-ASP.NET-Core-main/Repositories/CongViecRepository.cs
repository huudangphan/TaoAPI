using BookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Repositories
{
    public class CongViecRepository : ICongViecRepository
    {
        private readonly CongViecContext _congViecContext;
        public CongViecRepository(CongViecContext congViecContext)
        {
            _congViecContext = congViecContext;
        }
       
        public async Task<CongViec> Create(CongViec cv)
        {
            _congViecContext.Add(cv);
            await _congViecContext.SaveChangesAsync();
            return cv;

        }

        public async Task Delete(int id,int user_id,string day,string thoigian)
        {
            var cvRemove = await _congViecContext.CongViec.FindAsync(id,user_id,day,thoigian);
            _congViecContext.Remove(cvRemove);
            await _congViecContext.SaveChangesAsync();

        }

        public async Task<IEnumerable<CongViec>> Get()
        {
            return await _congViecContext.CongViec.ToListAsync();
        }

        public async Task<CongViec> Get(int id,int user_id,string day,string thoigian)
        {
            return await _congViecContext.CongViec.FindAsync(new object[] { id, user_id, day, thoigian });
        }

        public async Task Update(CongViec cv)
        {
            _congViecContext.Entry(cv).State = EntityState.Modified;
            await _congViecContext.SaveChangesAsync();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookAPI.Models;


namespace BookAPI.Repositories
{
    public interface ICongViecRepository
    {
        Task<IEnumerable<CongViec>> Get();
        Task<CongViec> Get(int id, int user_id,string day,string thoigian);
        Task<CongViec> Create(CongViec cv);
        Task Update(CongViec cv);
        Task Delete(int id,int user_id,string day,string thoigian);
    }
}

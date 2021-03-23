using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookAPI.Models;
using BookAPI.Repositories;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Account>> GetAccounts()
        {
            return await accountRepository.Get();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccount( int id)
        {
            return await accountRepository.Get(id);
        }
        [HttpPost]
        
        public async Task<ActionResult<Account>> PostAccount([FromBody] Account acc)
        {
            var newAcc = await accountRepository.Create(acc);
            return CreatedAtAction(nameof(GetAccount), new { id = newAcc.id }, newAcc);
        }
    }
}

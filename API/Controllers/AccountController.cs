using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        public AccountController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AppUser>> Register(RegisterDto RegisterDto){
            
            if(await UserExists(RegisterDto.UserName))
            return BadRequest("User already exists");
            using var hmac=new HMACSHA512();

            var user=new AppUser{
                 UserName=RegisterDto.UserName.ToLower(),
                 PasswordHash=hmac.ComputeHash(Encoding.UTF8.GetBytes(RegisterDto.Password)),
                 PasswordSalt=hmac.Key                 
            };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();   
        return user;          
        }

private async Task<bool> UserExists(string username){

return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());
}

    }
}
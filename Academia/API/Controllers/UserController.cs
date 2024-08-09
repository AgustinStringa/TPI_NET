using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Security.Cryptography;

namespace API.Controllers
{

    public class LoginDto {
        public string Username { get; set; }
        public string Password { get; set; }
        public LoginDto() { }
    }

    [Route("api/users")]
    [ApiController]
    public class UserController : Controller
    {
       


        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            try
            {
                var context = new API.AcademiaContext();
                return await context.Users.Include(u => u.Curriculum).ToListAsync();
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
                throw e;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            try
            {
                var context = new API.AcademiaContext();
                var user = await context.Users.FindAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                else
                {
                    return user;
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
                throw e;
            }
        }

        [HttpPost("auth")]
        public async Task<ActionResult<User>> Auth(LoginDto credentials)
        {
            try
            {
                var context = new API.AcademiaContext();
                
                var user = await context.Users.FirstAsync(u => (u.Username==credentials.Username));
                if (user != null)
                {
                    byte[] sentHashValue = Convert.FromHexString(user.Password);
                    byte[] messageBytes1 = Encoding.UTF8.GetBytes(credentials.Password);
                    byte[] compareHashValue = SHA256.HashData(messageBytes1);
                    if (sentHashValue.SequenceEqual(compareHashValue))
                    {
                        return user;
                    }
                    else
                    {
                        return StatusCode(401, new { message = "username or password wrong"});
                    }

                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
                throw e;
            }
        }

    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context ;
        public UsersController(DataContext context)
        {
            _context = context;

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers(){
               var users = await _context.Users.ToListAsync();
               return users;

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AppUser>> GetUsers(int id){
               var users = await _context.Users.FirstOrDefaultAsync(x=>x.Id == id);
               return users;

        }



    }
}
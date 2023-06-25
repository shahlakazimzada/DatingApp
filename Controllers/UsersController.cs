using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

//Asynchronous code
// asynchronous programming provides opportunities for a program 
//to continue running other code while waiting for a long-running task to complete.
// The time-consuming task is executed in the background while the rest of the code continues to execute.
namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UsersController: ControllerBase
    {
        private readonly DataContext _context;
        public UsersController (DataContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<AppUser>>>GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<AppUser>>GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user;
        }
        
    }
}
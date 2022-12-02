using EFAPIRelationsships.Data;
using EFAPIRelationsships.Moldes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFAPIRelationsships.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        //traz todos os users e seus personagens
        public async Task<ActionResult<List<User>>>Get()
        {
            var users = await _context.Users
                .Include(u => u.Characters)
                .ToListAsync();
            return users;
        }

        [HttpGet("user")]
        //traz todos os users e seus personagens por id
        public async Task<ActionResult<List<User>>> Get(int userId)
        {
            var users = await _context.Users
                .Where(u=> u.Id == userId)
                .Include(u => u.Characters)
                .ToListAsync();
            return users;
        }
    }
}

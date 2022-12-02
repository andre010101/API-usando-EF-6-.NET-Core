using EFAPIRelationsships.Data;
using EFAPIRelationsships.DTO;
using EFAPIRelationsships.Moldes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFAPIRelationsships.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly DataContext _context;

        public CharactersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Character>>>Get(int userId)
        {
            var characters = await _context.Characters
                .Where(x => x.UserId == userId)
                .ToListAsync();
            return characters;
        }


        [HttpPost]
        public async Task<ActionResult<List<Character>>> Create(CreateCharacterDTO request)
        {
            var user = await _context.Users.FindAsync(request.UserId);
            if(user == null)
            {
                return NotFound();
            }
            var newCharacter = new Character
            {
                Name = request.Name,
                PublisheBy = request.PublishedBy,
                User = user
            };
            _context.Characters.Add(newCharacter);
            await _context.SaveChangesAsync();

            return await Get(newCharacter.UserId);
        }

    }
}

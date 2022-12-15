using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToccanierGregoryApiPoker.Context;
using ToccanierGregoryApiPoker.DTO;
using ToccanierGregoryApiPoker.Entity;

namespace ToccanierGregoryApiPoker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        //////////////////////////// GET
        // get all
        [HttpGet]
        async public Task<ActionResult<List<User>?>> GetUsers()
        {
            return Ok(await _context.Users.ToListAsync());
        }
        // get by id
        [HttpGet("ByID/{id}")]
        async public Task<ActionResult<User?>> GetUserByID(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(p => p.id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        //////////////////////////// POST
        [HttpPost]
        async public Task<ActionResult> PostUser([FromBody] CreateUserRequest _CreateUserRequest)
        {
            // Création d'un nouvel utilisateur 
            User newUser = new User();

            // Affectation des valeurs depuis le DTO
            newUser.username = _CreateUserRequest.username;
            newUser.password = _CreateUserRequest.password;
            newUser.money = _CreateUserRequest.money;
            newUser.birth_date = _CreateUserRequest.birth_date;
            newUser.nb_games = _CreateUserRequest.nb_games;

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return Ok("Utilisateur ajouté");
        }
        //////////////////////////// PUT
        [HttpPut("{id}")]
        async public Task<ActionResult> PutUser(int id, CreateUserRequest _CreateUserRequest)
        {
            // Récuperer l'utilisteur
            User newUser = await _context.Users.FirstOrDefaultAsync(p => p.id == id);

            // Affectation des valeurs depuis le DTO
            newUser.username = _CreateUserRequest.username;
            newUser.password = _CreateUserRequest.password;
            newUser.money = _CreateUserRequest.money;
            newUser.birth_date = _CreateUserRequest.birth_date;
            newUser.nb_games = _CreateUserRequest.nb_games;

            _context.Entry(newUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
        }
        //////////////////////////// DELETE
        [HttpDelete("{id}")]
        public async Task DeleteUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(p => p.id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}

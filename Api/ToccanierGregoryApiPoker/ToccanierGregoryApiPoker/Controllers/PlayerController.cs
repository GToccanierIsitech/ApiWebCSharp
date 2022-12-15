using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToccanierGregoryApiPoker.Context;
using ToccanierGregoryApiPoker.DTO;
using ToccanierGregoryApiPoker.Entity;

namespace ToccanierGregoryApiPoker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PlayerController(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        [HttpGet]
        async public Task<ActionResult<List<Player>?>> GetPlayers()
        {
            return Ok(await _context.Players.ToListAsync());
        }
        [HttpGet("content/{id}")]
        async public Task<ActionResult<List<Player>?>> GetStatPlayer(int id)
        {
            Player _player = await _context.Players.FirstOrDefaultAsync(p => p.id == id);
            User _user = await _context.Users.FirstOrDefaultAsync(p => p.id == _player.user_id);

            SendPlayerData newdata = new SendPlayerData();
            newdata.username = _user.username;
            newdata.total_money = _user.money;
            newdata.ingame_money = _player.money;

            return Ok(newdata);
        }
    }
}

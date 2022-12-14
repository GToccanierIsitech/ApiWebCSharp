using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// Perso
using ToccanierGregoryApiWeb.Entity;
using ToccanierGregoryApiWeb.Context;
// JSON
using Newtonsoft.Json;

namespace ToccanierGregoryApiWeb.Controllers
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

        [HttpGet("ByID/{id}")]
        async public Task<ActionResult<Player?>> GetPlayerByID(int id)
        {
            var player = await _context.Players.FirstOrDefaultAsync(p => p.id == id);
            if (player == null)
            {
                return NotFound();
            }
            return Ok(player);
        }

        [HttpPost]
        async public Task<ActionResult> PostPlayer([FromBody] Player player)
        {
            _context.Players.Add(player);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPlayerByID), new { id = player.id }, player);
        }

        [HttpPut("{id}")]
        async public Task<ActionResult> PutPlayer(int id, [FromBody] Player player)
        {
            if (id != player.id)
            {
                return BadRequest();
            }

            _context.Entry(player).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            if (player != null)
            {
                return NoContent();
            }
        }

        [HttpDelete("{id}")]
        public async Task DeletePlayer(int id)
        {
            var player = await _context.Players.FirstOrDefaultAsync(p => p.id == id);
            if (player != null)
            {
                _context.Players.Remove(player);
                await _context.SaveChangesAsync();
            }
        }

    }
}
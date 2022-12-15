using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using ToccanierGregoryApiPoker.Context;
using ToccanierGregoryApiPoker.DTO;
using ToccanierGregoryApiPoker.Entity;

namespace ToccanierGregoryApiPoker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public GameController(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        //////////////////////////// GET
        // GET ALL
        [HttpGet]
        async public Task<ActionResult<List<Game>?>> GetGames()
        {
            return Ok(await _context.Games.ToListAsync());
        }


        // GET BY ID
        [HttpGet("{id}")]
        async public Task<ActionResult<Game?>> GetGameByID(int id)
        {
            var game = await _context.Games.FirstOrDefaultAsync(p => p.id == id);
            // Traitement de la réponse
            if (game == null) { return NotFound(); }
            return Ok(game);
        }
        //////////////////////////// POST
        [HttpPost]
        async public Task<ActionResult> PostGame([FromBody] CreateGameRequest _CreateGameRequest)
        {
            Game newGame = new Game();
            // Affectation des valeurs depuis le DTO
            newGame.pot = _CreateGameRequest.pot;
            newGame.buy_in = _CreateGameRequest.buy_in;
            newGame.max_players = _CreateGameRequest.max_players;
            // Ajouter la date d'aujourd'hui
            newGame.start_date = DateTime.UtcNow;
            // Ajouter la partie dans la bdd
            await _context.Games.AddAsync(newGame);
            await _context.SaveChangesAsync();

            return Ok();
        }
        //////////////////////////// PUT
        // Ajouter de l'argent dans le pot
        [HttpPut("{id}")]
        async public Task<ActionResult> PutGame(int id, CreateGameRequest _CreateGameRequest)
        {
            Game newGame = await _context.Games.FirstOrDefaultAsync(p => p.id == id);
            // Affectation des valeurs depuis le DTO
            newGame.pot = _CreateGameRequest.pot;
            newGame.buy_in = _CreateGameRequest.buy_in;
            newGame.max_players = _CreateGameRequest.max_players;

            // Modification dans le context
            _context.Entry(newGame).State = EntityState.Modified;

            // Sauvegarde
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
        // Ajouter de l'argent dans le pot
        [HttpPut("addmoney/{id}/{amount}")]
        async public Task<ActionResult> AddMoneyInPot(int id, int amount)
        {
            var game = await _context.Games.FirstOrDefaultAsync(p => p.id == id);
            // Traitement de la réponse
            if (game == null) { return NotFound(); }
            // Ajout du nouveau montant au pot
            game.pot += amount;
            // Modification dans le context
            _context.Entry(game).State = EntityState.Modified;

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
        // Retirer de l'argent du pot
        [HttpPut("removemoney/{id}/{amount}")]
        async public Task<ActionResult> RemoveMoneyInPot(int id, int amount)
        {
            var game = await _context.Games.FirstOrDefaultAsync(p => p.id == id);
            // Traitement de la réponse
            if (game == null) { return NotFound(); }
            // Ajout du nouveau montant au pot
            game.pot -= amount;
            // Modification dans le context
            _context.Entry(game).State = EntityState.Modified;

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
        // Finir la partie
        [HttpPut("stopGame/{id}")]
        async public Task<ActionResult> stopGame(int id)
        {

            var game = await _context.Games.FirstOrDefaultAsync(p => p.id == id);
            // Traitement de la réponse
            if (game == null) { return NotFound(); }
            if (game.end_date != null) { return Ok("La partie est déja terminée"); }
            // Ajouter la date d'aujourd'hui
            game.end_date = DateTime.Now;
            // Modification dans le context
            _context.Entry(game).State = EntityState.Modified;

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
        
        // Définir le pot
        [HttpPut("setmoney/{id}/{amount}")]
        async public Task<ActionResult> SetMoneyInPot(int id, int amount)
        {
            var game = await _context.Games.FirstOrDefaultAsync(p => p.id == id);
            // Traitement de la réponse
            if (game == null) { return NotFound(); }
            // Ajout du nouveau montant au pot
            game.pot = amount;
            // Modification dans le context
            _context.Entry(game).State = EntityState.Modified;

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

    }
}

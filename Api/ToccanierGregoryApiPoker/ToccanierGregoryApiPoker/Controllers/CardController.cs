using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToccanierGregoryApiPoker.Context;
using ToccanierGregoryApiPoker.DTO;
using ToccanierGregoryApiPoker.Entity;

namespace ToccanierGregoryApiPoker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CardController(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        //////////////////////////// GET
        [HttpGet]
        async public Task<ActionResult<List<Card>?>> GetCards()
        {
            return Ok(await _context.Cards.ToListAsync());
        }

        [HttpGet("game/{game_id}")]
        async public Task<ActionResult<List<Card>?>> GetGameCards(int game_id)
        {
            return Ok(await _context.Cards
                .Where(card => card.game_id == game_id)
                .Select(card => new {
                    card.name,
                    card.couleur,
                    card.symbole,
                    card.values
                })
                .ToListAsync());
        }
        [HttpGet("player/{player_id}")]
        async public Task<ActionResult<List<Player>?>> GetPlayerCards(int player_id)
        {
            return Ok(await _context.Cards
                .Where(card => card.player_id == player_id)
                .Select(card => new {
                    card.name,
                    card.couleur,
                    card.symbole,
                    card.values
                })
                .ToListAsync());
        }
        //////////////////////////// POST
        [HttpPost]
        async public Task<ActionResult> PostCard([FromBody] CreateCardRequest _createCardRequest)
        {
            // Création de la nouvelle carte
            Card newCard = new Card();

            // Affectation des valeurs depuis le DTO
            newCard.name = _createCardRequest.name;
            newCard.couleur = _createCardRequest.couleur;
            newCard.player_id = _createCardRequest.player_id;
            newCard.game_id = _createCardRequest.game_id;

            // Récupération de la values de la carte a partir de son nom
            newCard.values = SetValues(newCard.name);
            // Récupération du symbole de la cartre a partir de son nom
            newCard.symbole = SetSymbole(newCard.name);

            // Ajouter la carte dans la bdd
            await _context.Cards.AddAsync(newCard);
            await _context.SaveChangesAsync();

            return Ok();
        }
        //////////////////////////// DELETE
        [HttpDelete("{id}")]
        public async Task DeleteCard(int id)
        {
            var card = await _context.Cards.FirstOrDefaultAsync(p => p.id == id);

            _context.Cards.Remove(card);
            await _context.SaveChangesAsync();
        }
        //////////////////////////// Fonction Utilitaire

        private int SetValues(string card_name)
        {
            switch(card_name) {
                case "As":
                    return 14;
                case "Deux":
                    return 2;
                case "Trois":
                    return 3;
                case "Quatre":
                    return 4;
                case "Cinq":
                    return 5;
                case "Six":
                    return 6;
                case "Sept":
                    return 7;
                case "Huit":
                    return 8;
                case "Neuf":
                    return 9;
                case "Dix":
                    return 10;
                case "Valet":
                    return 11;
                case "Dame":
                    return 12;
                case "Roi":
                    return 13;
                default:
                    return 0;
            
            }
        }
        private string SetSymbole(string card_name)
        {
            switch (card_name)
            {
                case "As":
                    return "A";
                case "Deux":
                    return "2";
                case "Trois":
                    return "3";
                case "Quatre":
                    return "4";
                case "Cinq":
                    return "5";
                case "Six":
                    return "6";
                case "Sept":
                    return "7";
                case "Huit":
                    return "8";
                case "Neuf":
                    return "9";
                case "Dix":
                    return "10";
                case "Valet":
                    return "J";
                case "Dame":
                    return "Q";
                case "Roi":
                    return "K";
                default:
                    return "0";

            }
        }
    }
}


using Microsoft.Extensions.Hosting;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToccanierGregoryApiPoker.Entity
{
    public class Player
    {
        public int id { get; set; }
        public int? money { get; set; }
        // CLE ETRANGERE GAME ID
        public int? game_id { get; set; }
        // CLE ETRANGERE USER ID
        public int? user_id { get; set; }

        // Relations
        public List<Card>? card { get; set; }
        public Game? game { get; set; }
        public User? user { get; set; }
    }
}

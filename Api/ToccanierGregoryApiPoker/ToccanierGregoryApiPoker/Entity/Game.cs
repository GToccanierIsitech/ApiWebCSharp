using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToccanierGregoryApiPoker.Entity
{
    public class Game
    {
        public int id { get; set; }
        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }
        public int? pot { get; set; }
        public int? buy_in { get; set; }
        public int? max_players { get; set; }


        // Relations
        public List<Player>? player { get; set; }
        public List<Card>? card { get; set; }
    }
}

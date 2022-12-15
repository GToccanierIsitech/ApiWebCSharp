using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ToccanierGregoryApiPoker.Entity
{
    public class Card
    {
        // ID
        public int id { get; set; }
        [Column(TypeName = "ENUM(\"As\", \"Deux\", \"Trois\", \"Quatre\", \"Cinq\", \"Six\", \"Sept\", \"Huit\", \"Neuf\", \"Dix\", \"Valet\", \"Dame\", \"Roi\")")]
        // NAME 
        [Required]
        public string? name { get; set; }
        [Column(TypeName = "ENUM(\"Trèfle\", \"Carreau\", \"Coeur\", \"Pique\")")]
        // COULEUR
        [Required]
        public string? couleur { get; set; }
        [Column(TypeName = "ENUM(\"A\", \"2\", \"3\", \"4\", \"5\", \"6\", \"7\", \"8\", \"9\", \"10\", \"J\", \"Q\", \"K\")")]
        // SYMBOLE
        [Required]
        public string? symbole { get; set; }
        // VALUES
        [Required]
        public int? values { get; set; }
        // CLE ETRANGERE PLAYER ID
        public int? player_id { get; set; }
        // CLE ETRANGERE GAME ID
        public int? game_id { get; set; }

        ///// Relations
        public Player? player { get; set; }
        public Game? game { get; set; }
    }
}

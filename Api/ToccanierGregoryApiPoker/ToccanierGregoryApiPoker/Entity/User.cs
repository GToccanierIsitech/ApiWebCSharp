using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToccanierGregoryApiPoker.Entity
{
    public class User
    {
        public int id { get; set; }

        [Column(TypeName = "Varchar(30)")]
        public string? username { get; set; }
        [Column(TypeName = "Varchar(50)")]
        public string? password { get; set; }
        public int? money { get; set; }
        public DateTime? birth_date { get; set; }
        public int? nb_games { get; set; }

        // Relations
        public Player player { get; set; }
    }
}

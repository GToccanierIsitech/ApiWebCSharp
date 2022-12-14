using System.ComponentModel.DataAnnotations.Schema;

namespace ToccanierGregoryApiWeb.Entity
{
    public class Player
    {
        public int? id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? lastname { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? firstname { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? username { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? password { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? age { get; set; }
        public int? money { get; set; }
        public int? nbr_games { get; set; }
    }
}
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToccanierGregoryApiPoker.DTO
{
    public class CreateUserRequest
    {
        public string? username { get; set; }
        public string? password { get; set; }
        public int? money { get; set; }
        public DateTime? birth_date { get; set; }
        public int? nb_games { get; set; }
    }
}

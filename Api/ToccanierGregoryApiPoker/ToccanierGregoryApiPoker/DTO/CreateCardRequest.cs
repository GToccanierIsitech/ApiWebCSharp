namespace ToccanierGregoryApiPoker.DTO
{
    public class CreateCardRequest
    {
        public string? name { get; set; }
        public string? couleur { get; set; }
        public Nullable<int> player_id { get; set; }
        public Nullable<int> game_id { get; set; }
    }
}

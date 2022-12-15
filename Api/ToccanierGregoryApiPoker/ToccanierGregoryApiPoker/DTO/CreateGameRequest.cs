namespace ToccanierGregoryApiPoker.DTO
{
    public class CreateGameRequest
    {
        public int? pot { get; set; }
        public int? buy_in { get; set; }
        public int? max_players { get; set; }
}
}

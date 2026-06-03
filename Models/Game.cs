namespace GameStore.Models
{
    public class Game
    {
        public int Id { get; set; }
        public required string Name{ get; set; }
        public Genre? Genre { get; set; }
        public int GenreId { get; set; }
        public DateOnly RelaseDate { get; set; }

    }
}

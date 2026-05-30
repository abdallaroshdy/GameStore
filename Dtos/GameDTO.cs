
namespace GameStore.Dtos
{
    public record GameDTO(
        int Id,
        string Name ,
        string Genre,
        decimal Price,
        DateOnly RelaseDate
    );
}

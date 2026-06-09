namespace GameStore.Dtos
{
    public record GameDetilesDTO
    (
        int Id,
        string Name,
        int GenreId,
        decimal Price,
        DateOnly RelaseDate
    );
}

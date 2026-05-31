namespace GameStore.Dtos
{
    public record CreateGameDTO(
        string Name,
        string Genre,
        decimal Price,
        DateOnly RelaseDate
            
    );
}

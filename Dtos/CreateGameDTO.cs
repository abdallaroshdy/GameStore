using System.ComponentModel.DataAnnotations;

namespace GameStore.Dtos
{
    public record CreateGameDTO(
        [Required][StringLength(50)] string Name,
        [Required][Range(1,50)] int GenreId,
        [Required][Range(1,1000)] decimal Price,
        DateOnly RelaseDate
            
    );
}

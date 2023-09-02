using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Data.Dtos;

public class UpdateMovieTheaterDto
{
  [Required(ErrorMessage = "Please provide a name for the movie theater")]
  public string Name { get; set; } = default!;
}
using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Data.Dtos;

public class CreateMovieTheaterDto
{
  [Required(ErrorMessage = "Please provide a title for the movie")]
  public string Name { get; set; } = default!;

  public int AddressId { get; set; } = default!;
}
using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Data.Dtos;

public class CreateSessionDto
{
  [Required]
  public int MovieId { get; set; } = default!;

  [Required]
  public int MovieTheaterId { get; set; } = default!;
}
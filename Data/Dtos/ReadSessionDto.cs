using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Data.Dtos;

public class ReadSessionDto
{
  public int MovieId { get; set; } = default!;

  public int MovieTheaterId { get; set; } = default!;
}
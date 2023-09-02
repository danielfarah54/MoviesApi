using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Data.Dtos;

public class ReadMovieDto
{
  public string Title { get; set; } = default!;

  public string Genre { get; set; } = default!;

  public int Length { get; set; } = default!;

  public DateTime QueriedAt { get; set; } = DateTime.Now;

  public ICollection<ReadSessionDto> Sessions { get; set; } = default!;
}
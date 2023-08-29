using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Data.Dtos;

public class ReadMovieDto
{
  public string Title { get; set; }

  public string Genre { get; set; }

  public int Length { get; set; }

  public DateTime QueriedAt { get; set; } = DateTime.Now;
}
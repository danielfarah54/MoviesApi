using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Models;

public class Session
{
  public int? MovieId { get; set; } = default!;

  public virtual Movie Movie { get; set; } = default!;

  public int? MovieTheaterId { get; set; } = default!;

  public virtual MovieTheater MovieTheater { get; set; } = default!;
}
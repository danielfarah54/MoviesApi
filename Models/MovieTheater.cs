using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Models;

public class MovieTheater
{
  [Key]
  [Required]
  public int Id { get; internal set; } = default!;

  [Required(ErrorMessage = "Please provide a name for the movie theater")]
  public string Name { get; set; } = default!;

  public int AddressId { get; set; } = default!;

  public virtual Address Address { get; set; } = default!;

  public virtual ICollection<Session> Sessions { get; set; } = default!;
}
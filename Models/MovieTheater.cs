using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Models;

public class MovieTheater
{
  [Key]
  [Required]
  public int Id { get; internal set; }

  [Required(ErrorMessage = "Please provide a name for the movie theater")]
  public string Name { get; set; }

  public int AddressId { get; set; }

  public virtual Address Address { get; set; }
}
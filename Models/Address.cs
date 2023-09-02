using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Models;

public class Address
{
  [Key]
  [Required]
  public int Id { get; internal set; } = default!;

  [Required(ErrorMessage = "Please provide the address street")]
  public string Street { get; set; } = default!;

  public int Number { get; set; } = default!;

  public virtual MovieTheater MovieTheater { get; set; } = default!;
}
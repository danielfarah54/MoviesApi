using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Models;

public class Address
{
  [Key]
  [Required]
  public int Id { get; internal set; }

  [Required(ErrorMessage = "Please provide the address street")]
  public string Street { get; set; }

  public int Number { get; set; }

  public virtual MovieTheater MovieTheater { get; set; }
}
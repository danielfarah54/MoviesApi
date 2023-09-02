using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Data.Dtos;

public class CreateAddressDto
{
  [Required(ErrorMessage = "Please provide the address street")]
  public string Street { get; set; } = default!;

  public int Number { get; set; } = default!;
}
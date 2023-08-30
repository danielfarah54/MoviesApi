using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Data.Dtos;

public class UpdateAddressDto
{
  [Required(ErrorMessage = "Please provide the address street")]
  public string Street { get; set; }

  public int Number { get; set; }
}
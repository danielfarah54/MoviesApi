using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Data.Dtos;

public class ReadAddressDto
{
  public int Id { get; set; } = default!;

  public string Street { get; set; } = default!;

  public int Number { get; set; } = default!;
}
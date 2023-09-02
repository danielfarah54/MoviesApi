namespace MoviesApi.Data.Dtos;

public class ReadMovieTheaterDto
{
  public string Id { get; set; } = default!;

  public string Name { get; set; } = default!;

  public ReadAddressDto Address { get; set; } = default!;

  public ICollection<ReadSessionDto> Sessions { get; set; } = default!;
}
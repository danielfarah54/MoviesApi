namespace MoviesApi.Data.Dtos;

public class ReadMovieTheaterDto
{
  public string Id { get; set; }

  public string Name { get; set; }

  public ReadAddressDto Address { get; set; }
}
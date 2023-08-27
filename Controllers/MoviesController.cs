using Microsoft.AspNetCore.Mvc;
using MoviesApi.Models;

namespace MoviesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController : ControllerBase
{
  private static List<Movie> movies = new List<Movie>();

  [HttpPost]
  public void AddMovie([FromBody] Movie movie)
  {
    movies.Add(movie);
  }
}
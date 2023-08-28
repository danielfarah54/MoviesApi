using Microsoft.AspNetCore.Mvc;
using MoviesApi.Models;
using MoviesApi.Data;

namespace MoviesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController : ControllerBase
{
  private MovieContext _context;

  public MoviesController(MovieContext context)
  {
    _context = context;
  }

  [HttpPost]
  public IActionResult AddMovie([FromBody] Movie movie)
  {
    _context.Movies.Add(movie);
    _context.SaveChanges();
    return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
  }

  [HttpGet]
  public IEnumerable<Movie> GetMovies([FromQuery] int page = 1)
  {
    int pageSize = 5;
    return _context.Movies.Skip((page - 1) * pageSize).Take(pageSize);
  }

  [HttpGet("{id}")]
  public IActionResult GetMovieById(int id)
  {
    var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
    if (movie == null)
    {
      return NotFound();
    }
    return Ok(movie);
  }
}
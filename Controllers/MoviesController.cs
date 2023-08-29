using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Models;
using MoviesApi.Data;
using MoviesApi.Data.Dtos;
using Microsoft.AspNetCore.JsonPatch;

namespace MoviesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController : ControllerBase
{
  private MovieContext _context;
  private IMapper _mapper;

  public MoviesController(MovieContext context, IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }

  [HttpPost]
  public IActionResult AddMovie([FromBody] CreateMovieDto movieDto)
  {
    Movie movie = _mapper.Map<Movie>(movieDto);
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

  [HttpPut("{id}")]
  public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieDto movieDto)
  {
    var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
    if (movie == null)
    {
      return NotFound();
    }
    _mapper.Map(movieDto, movie);
    _context.SaveChanges();
    return NoContent();
  }

  [HttpPatch("{id}")]
  public IActionResult PartialUpdateMovie(int id, [FromBody] JsonPatchDocument<UpdateMovieDto> patchDoc)
  {
    var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
    if (movie == null)
    {
      return NotFound();
    }

    var movieToPatch = _mapper.Map<UpdateMovieDto>(movie);
    patchDoc.ApplyTo(movieToPatch, ModelState);
    if (!TryValidateModel(movieToPatch))
    {
      return ValidationProblem(ModelState);
    }

    _mapper.Map(movieToPatch, movie);
    _context.SaveChanges();
    return NoContent();
  }

  [HttpDelete("{id}")]
  public IActionResult DeleteMovie(int id)
  {
    var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
    if (movie == null)
    {
      return NotFound();
    }
    _context.Movies.Remove(movie);
    _context.SaveChanges();
    return NoContent();
  }
}
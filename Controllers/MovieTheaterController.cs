using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Models;
using MoviesApi.Data;
using MoviesApi.Data.Dtos;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace MoviesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieTheaterController : ControllerBase
{
  private MovieContext _context;
  private IMapper _mapper;

  public MovieTheaterController(MovieContext context, IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }

  [HttpPost]
  public IActionResult AddMovieTheater([FromBody] CreateMovieTheaterDto movieTheaterDto)
  {
    MovieTheater movieTheater = _mapper.Map<MovieTheater>(movieTheaterDto);
    _context.MovieTheaters.Add(movieTheater);
    _context.SaveChanges();
    return CreatedAtAction(nameof(GetMovieTheaterById), new { id = movieTheater.Id }, movieTheater);
  }

  [HttpGet]
  public IEnumerable<ReadMovieTheaterDto> GetMovieTheaters([FromQuery] int page = 1, [FromQuery] int? addressId = null)
  {
    int pageSize = 5;

    if (addressId == null)
    {
      return _mapper.Map<List<ReadMovieTheaterDto>>(
        _context.MovieTheaters.Skip((page - 1) * pageSize).Take(pageSize).ToList()
      );
    }

    return _mapper.Map<List<ReadMovieTheaterDto>>(
      _context.MovieTheaters.Where(movieTheater => movieTheater.AddressId == addressId).Skip((page - 1) * pageSize).Take(pageSize).ToList()
    );
  }

  [HttpGet("{id}")]
  public IActionResult GetMovieTheaterById(int id)
  {
    var movieTheater = _context.MovieTheaters.FirstOrDefault(movieTheater => movieTheater.Id == id);
    if (movieTheater == null)
    {
      return NotFound();
    }

    var movieTheaterDto = _mapper.Map<ReadMovieTheaterDto>(movieTheater);
    return Ok(movieTheaterDto);
  }

  [HttpPut("{id}")]
  public IActionResult UpdateMovieTheater(int id, [FromBody] UpdateMovieTheaterDto movieTheaterDto)
  {
    var movieTheater = _context.MovieTheaters.FirstOrDefault(movieTheater => movieTheater.Id == id);
    if (movieTheater == null)
    {
      return NotFound();
    }
    _mapper.Map(movieTheaterDto, movieTheater);
    _context.SaveChanges();
    return NoContent();
  }

  [HttpPatch("{id}")]
  public IActionResult PartialUpdateMovieTheater(int id, [FromBody] JsonPatchDocument<UpdateMovieTheaterDto> patchDoc)
  {
    var movieTheater = _context.MovieTheaters.FirstOrDefault(movieTheater => movieTheater.Id == id);
    if (movieTheater == null)
    {
      return NotFound();
    }

    var movieTheaterToPatch = _mapper.Map<UpdateMovieTheaterDto>(movieTheater);
    patchDoc.ApplyTo(movieTheaterToPatch, ModelState);
    if (!TryValidateModel(movieTheaterToPatch))
    {
      return ValidationProblem(ModelState);
    }

    _mapper.Map(movieTheaterToPatch, movieTheater);
    _context.SaveChanges();
    return NoContent();
  }

  [HttpDelete("{id}")]
  public IActionResult DeleteMovieTheater(int id)
  {
    var movieTheater = _context.MovieTheaters.FirstOrDefault(movieTheater => movieTheater.Id == id);
    if (movieTheater == null)
    {
      return NotFound();
    }
    _context.MovieTheaters.Remove(movieTheater);
    _context.SaveChanges();
    return NoContent();
  }
}
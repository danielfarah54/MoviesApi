using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Models;
using MoviesApi.Data;
using MoviesApi.Data.Dtos;

namespace MoviesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SessionController : ControllerBase
{
  private MovieContext _context;
  private IMapper _mapper;

  public SessionController(MovieContext context, IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }

  [HttpPost]
  public IActionResult AddSession([FromBody] CreateSessionDto sessionDto)
  {
    Session session = _mapper.Map<Session>(sessionDto);
    _context.Sessions.Add(session);
    _context.SaveChanges();
    return CreatedAtAction(nameof(GetSessionById), new
    {
      movieId = session.MovieId,
      movieTheaterId = session.MovieTheaterId
    }, session);
  }

  [HttpGet]
  public IEnumerable<ReadSessionDto> GetSessions([FromQuery] int page = 1)
  {
    int pageSize = 5;
    return _mapper.Map<List<ReadSessionDto>>(
      _context.Sessions.Skip((page - 1) * pageSize).Take(pageSize).ToList()
    );
  }

  [HttpGet("{movieId}/{movieTheaterId}")]
  public IActionResult GetSessionById(int movieId, int movieTheaterId)
  {
    var session = _context.Sessions.FirstOrDefault(session =>
      session.MovieId == movieId && session.MovieTheaterId == movieTheaterId
    );
    if (session == null)
    {
      return NotFound();
    }

    var sessionDto = _mapper.Map<ReadSessionDto>(session);
    return Ok(sessionDto);
  }
}
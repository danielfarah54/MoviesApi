using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Models;
using MoviesApi.Data;
using MoviesApi.Data.Dtos;
using Microsoft.AspNetCore.JsonPatch;

namespace MoviesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController : ControllerBase
{
  private MovieContext _context;
  private IMapper _mapper;

  public AddressController(MovieContext context, IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }

  [HttpPost]
  public IActionResult AddAddress([FromBody] CreateAddressDto addressDto)
  {
    Address address = _mapper.Map<Address>(addressDto);
    _context.Addresses.Add(address);
    _context.SaveChanges();
    return CreatedAtAction(nameof(GetAddressById), new { id = address.Id }, address);
  }

  [HttpGet]
  public IEnumerable<ReadAddressDto> GetAddresses([FromQuery] int page = 1)
  {
    int pageSize = 5;
    return _mapper.Map<List<ReadAddressDto>>(
      _context.Addresses.Skip((page - 1) * pageSize).Take(pageSize).ToList()
    );
  }

  [HttpGet("{id}")]
  public IActionResult GetAddressById(int id)
  {
    var address = _context.Addresses.FirstOrDefault(address => address.Id == id);
    if (address == null)
    {
      return NotFound();
    }

    var addressDto = _mapper.Map<ReadAddressDto>(address);
    return Ok(addressDto);
  }

  [HttpPut("{id}")]
  public IActionResult UpdateAddress(int id, [FromBody] UpdateAddressDto addressDto)
  {
    var address = _context.Addresses.FirstOrDefault(address => address.Id == id);
    if (address == null)
    {
      return NotFound();
    }
    _mapper.Map(addressDto, address);
    _context.SaveChanges();
    return NoContent();
  }

  [HttpPatch("{id}")]
  public IActionResult PartialUpdateAddress(int id, [FromBody] JsonPatchDocument<UpdateAddressDto> patchDoc)
  {
    var address = _context.Addresses.FirstOrDefault(address => address.Id == id);
    if (address == null)
    {
      return NotFound();
    }

    var addressToPatch = _mapper.Map<UpdateAddressDto>(address);
    patchDoc.ApplyTo(addressToPatch, ModelState);
    if (!TryValidateModel(addressToPatch))
    {
      return ValidationProblem(ModelState);
    }

    _mapper.Map(addressToPatch, address);
    _context.SaveChanges();
    return NoContent();
  }

  [HttpDelete("{id}")]
  public IActionResult DeleteAddress(int id)
  {
    var address = _context.Addresses.FirstOrDefault(address => address.Id == id);
    if (address == null)
    {
      return NotFound();
    }
    _context.Addresses.Remove(address);
    _context.SaveChanges();
    return NoContent();
  }
}
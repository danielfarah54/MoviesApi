using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Models;

public class Movie
{
  [Key]
  [Required]
  public int Id { get; internal set; }

  [Required(ErrorMessage = "Please provide a title for the movie")]
  [MaxLength(100, ErrorMessage = "The title cannot be longer than 100 characters")]
  public string Title { get; set; }

  [Required(ErrorMessage = "Please provide a genre for the movie")]
  [MaxLength(50, ErrorMessage = "The genre cannot be longer than 50 characters")]
  public string Genre { get; set; }

  [Required(ErrorMessage = "Please provide a length for the movie")]
  [Range(70, 600, ErrorMessage = "The length must be between 70 and 600 minutes")]
  public int Length { get; set; }
}
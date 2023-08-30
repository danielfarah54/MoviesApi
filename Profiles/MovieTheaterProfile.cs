using AutoMapper;
using MoviesApi.Data.Dtos;
using MoviesApi.Models;

namespace MoviesApi.Profiles;

public class MovieTheaterProfile : Profile
{
  public MovieTheaterProfile()
  {
    CreateMap<CreateMovieTheaterDto, MovieTheater>();
    CreateMap<UpdateMovieTheaterDto, MovieTheater>();
    CreateMap<MovieTheater, UpdateMovieTheaterDto>();
    CreateMap<MovieTheater, ReadMovieTheaterDto>();
  }
}
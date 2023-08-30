using AutoMapper;
using MoviesApi.Data.Dtos;
using MoviesApi.Models;

namespace MoviesApi.Profiles;

public class AddressProfile : Profile
{
  public AddressProfile()
  {
    CreateMap<CreateAddressDto, Address>();
    CreateMap<UpdateAddressDto, Address>();
    CreateMap<Address, UpdateAddressDto>();
    CreateMap<Address, ReadAddressDto>();
  }
}
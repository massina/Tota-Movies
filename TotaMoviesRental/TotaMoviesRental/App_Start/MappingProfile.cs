using AutoMapper;
using TotaMoviesRental.Dtos;
using TotaMoviesRental.Models;

namespace TotaMoviesRental.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // From domain to dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();

            // From dto to domain
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<MembershipTypeDto, MembershipType>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<GenreDto, Genre>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}
using AddressBook.Domain.Models;
using AddressBook.DTOs;
using AutoMapper;

namespace AddressBook.HelpClasses
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Country mappings
            CreateMap<Country, CountryGetDTO>()
                .ForMember(dest => dest.CountryId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Name));

            // City mappings
            CreateMap<City, CityGetDTO>()
                .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.CountryId, opt => opt.MapFrom(src => src.CountryId));

            // Contact mappings
            CreateMap<Contact, ContactGetDTO>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.EmailAddress))
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City.Name))
                .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.City.Country.Name))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender == Gender.Male ? "Male" : "Female"));

            CreateMap<ContactPostDTO, Contact>()
                .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(src => src.EmailAddress))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => (Gender)src.Gender));
        }
    }
}

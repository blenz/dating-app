using System.Linq;
using AutoMapper;
using DatingApp.Models;
using DatingApp.Dto;

namespace DatingApp.Helpers
{

    public class AutoMapperProfiles : Profile
    {

        public AutoMapperProfiles()
        {
            CreateMap<UserForUpdate, User>();
            CreateMap<Photo, PhotoForDetailedDto>();
            CreateMap<Photo, PhotoForReturnDto>();
            CreateMap<PhotoForCreationDto, Photo>();
            CreateMap<UserRegisterDto, User>();
            CreateMap<User, UserDetailDto>()
                .ForMember(dest => dest.PhotoUrl, opts =>
                {
                    opts.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                })
                .ForMember(dest => dest.Age, opts =>
                {
                    opts.ResolveUsing(d => d.DateOfBirth.CalculateAge());
                });

            CreateMap<User, UserListDto>()
                .ForMember(dest => dest.PhotoUrl, opts =>
                {
                    opts.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                })
                .ForMember(dest => dest.Age, opts =>
                {
                    opts.ResolveUsing(d => d.DateOfBirth.CalculateAge());
                });
        }
    }
}

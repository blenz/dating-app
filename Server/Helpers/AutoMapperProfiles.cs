using System.Linq;
using AutoMapper;
using DatingApp.Dto;
using DatingApp.Models;

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
            CreateMap<MessageForCreationDto, Message>()
                .ReverseMap();
            CreateMap<Message, MessageToReturnDto>()
                .ForMember(m => m.SenderPhotoUrl, opts =>
                    opts.MapFrom(u => u.Sender.Photos.FirstOrDefault(p => p.IsMain).Url))
                .ForMember(m => m.RecipientPhotoUrl, opts =>
                    opts.MapFrom(u => u.Recipient.Photos.FirstOrDefault(p => p.IsMain).Url));
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

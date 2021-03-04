using System;
using System.Linq;
using api.Entities;
using API.Domain;
using API.Dtos;
using API.Dtos.ClubDto;
using API.Entities;
using API.Extenstions;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>()
                .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.isMain).Url))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
            CreateMap<Photo, PhotoDto>();
            CreateMap<MemberUpdateDto, AppUser>();
            CreateMap<UserForOnboardDto, AppUser>();
            CreateMap<Message, MessageDto>()
                .ForMember(dest => dest.SenderPhotoUrl, opt => opt.MapFrom(src => src.Sender.Photos.FirstOrDefault(x => x.isMain).Url))
                .ForMember(dest => dest.RecipientPhotoUrl, opt => opt.MapFrom(src => src.Recipient.Photos.FirstOrDefault(x => x.isMain).Url));
            CreateMap<RegisterDto, AppUser>();
            CreateMap<CreateClubDto, Club>();
            CreateMap<Club, ClubDto>();
            CreateMap<ClubDto, ClubDto>();
            CreateMap<Blog, Blog>();
        }
    }
}
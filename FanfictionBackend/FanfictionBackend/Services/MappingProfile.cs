using AutoMapper;
using FanfictionBackend.Dto;
using FanfictionBackend.Models;

namespace FanfictionBackend.Services;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Fanfic, FanficDto>()
            .ForMember(d => d.AuthorName, opt
                => opt.MapFrom(src => src.Author.Username))
            .ForMember(d => d.NumLikes, opt
                => opt.MapFrom(src => src.Likes.Count));

        CreateMap<AddFanficDto, Fanfic>();
        
        CreateMap<Chapter, ChapterDto>();
        CreateMap<AddChapterDto, Chapter>();
        
        CreateMap<UserDto, User>();
        CreateMap<User, UserDto>()
            .ForMember(d => d.NumFanfics, opt
                => opt.MapFrom(src => src.Fanfics.Count));
        
        CreateMap<RegisterDto, User>();
    }
}
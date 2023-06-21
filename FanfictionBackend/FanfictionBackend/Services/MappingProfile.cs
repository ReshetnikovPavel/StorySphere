using AutoMapper;
using FanfictionBackend.Dto;
using FanfictionBackend.Models;

namespace FanfictionBackend.Services;

public class MappingProfile : Profile
{
    public MappingProfile(ICategoryParser categoryParser, IAgeLimitParser ageLimitParser)
    {
        CreateMap<Fanfic, FanficDto>()
            .ForMember(d => d.AuthorName, opt
                => opt.MapFrom(src => src.Author.Username))
            .ForMember(d => d.NumLikes, opt
                => opt.MapFrom(src => src.Likes.Count))
            .ForMember(f => f.Category,
                opt => opt.MapFrom(src => categoryParser.Parse(src.Category)))
            .ForMember(f => f.AgeLimit,
                opt => opt.MapFrom(src => ageLimitParser.Parse(src.AgeLimit)));

        CreateMap<AddFanficDto, Fanfic>()
            .ForMember(f => f.Category,
                opt => opt.MapFrom(src => categoryParser.Parse(src.Category)))
            .ForMember(f => f.AgeLimit,
                opt => opt.MapFrom(src => ageLimitParser.Parse(src.AgeLimit)));
        
        CreateMap<Chapter, ChapterDto>();
        CreateMap<AddChapterDto, Chapter>();
        
        CreateMap<UserDto, User>();
        CreateMap<User, UserDto>()
            .ForMember(d => d.NumFanfics, opt
                => opt.MapFrom(src => src.Fanfics.Count));
        
        CreateMap<RegisterDto, User>();
    }
}
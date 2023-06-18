using AutoMapper;
using FanfictionBackend.Dto;
using FanfictionBackend.Models;

namespace FanfictionBackend.Services;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Fanfic, FanficDto>();
        CreateMap<FanficDto, Fanfic>();
        CreateMap<Chapter, ChapterDto>();
        CreateMap<ChapterDto, Chapter>();
        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>();
    }
}
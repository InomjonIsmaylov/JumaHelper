using AutoMapper;
using JumaHelper.Server.Models.DbSets;
using JumaHelper.Server.Models.Dtos;

namespace JumaHelper.Server.Extensions;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<DuaRequest, DuaRequestDto>().ReverseMap();
            
        CreateMap<DuaRequestOwner, DuaRequestOwnerDto>().ReverseMap();
            
        CreateMap<DuaRequestType, DuaRequestTypeDto>().ReverseMap();
    }
}
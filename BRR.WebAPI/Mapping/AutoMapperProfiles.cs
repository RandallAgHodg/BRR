using AutoMapper;
using BRR.Application.Auth.Register;
using BRR.WebAPI.Extensions;
using BRR.WebAPI.Requests;

namespace BRR.WebAPI.Mapping;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<RegisterRequest, RegisterAgentCommand>()
            .ForMember(x => x.ProfilePicture, x => 
            x.MapFrom(x => x.ProfilePicture.ToImageUploadParams()))
            .ReverseMap();


    }
}

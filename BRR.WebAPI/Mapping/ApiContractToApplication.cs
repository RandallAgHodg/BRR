using BRR.Application.Auth.Register;
using BRR.WebAPI.Extensions;
using BRR.WebAPI.Requests;

namespace BRR.WebAPI.Mapping;

public static class ApiContractToApplication
{
    public static RegisterAgentCommand ToCommand(this RegisterRequest request) =>
        new RegisterAgentCommand(request.FirstName, request.LastName, request.PhoneNumber, request.Email, request.Password,
            request.ProfilePicture.ToImageUploadParams());
}

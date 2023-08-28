using BRR.Contracts.Requests.Users;

namespace BRR.WebAPI.Requests;

public sealed class RegisterRequest : CreateUserRequest
{
    public IFormFile ProfilePicture { get; set; }
}

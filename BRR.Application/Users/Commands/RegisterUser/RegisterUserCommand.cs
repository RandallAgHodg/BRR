using BRR.Application.Abstractions.Messaging;
using BRR.Contracts.Responses.Users;
using CloudinaryDotNet.Actions;

namespace BRR.Application.Users.Commands.RegisterUser;

public sealed record RegisterUserCommand(
    string FirstName,
    string SecondName,
    string LastName,
    string SecondLastName,
    string Email,
    string Password,
    int Age,
    string PhoneNumber,
    string Gender,
    string Role,
    ImageUploadParams ProfilePicture
) : ICommand<AuthResponse>;

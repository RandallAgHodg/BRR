using BRR.Application.Abstractions.Messaging;
using BRR.Contracts.Responses.Users;
using CloudinaryDotNet.Actions;
using System.Windows.Input;

namespace BRR.Application.Auth.Register;

public sealed record RegisterAgentCommand (string FirstName, string LastName, string PhoneNumber, string Email, string Password, ImageUploadParams ProfilePicture) : ICommand<AuthResponse>;

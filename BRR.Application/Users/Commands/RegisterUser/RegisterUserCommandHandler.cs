using BRR.Application.Abstractions.Authentication;
using BRR.Application.Abstractions.FileStorer;
using BRR.Application.Abstractions.Messaging;
using BRR.Application.Core.Exceptions.User;
using BRR.Application.Mapping;
using BRR.Contracts.Responses.Users;
using BRR.Domain.Entities;
using BRR.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BRR.Application.Users.Commands.RegisterUser;

public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, AuthResponse>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IJWTProvider _jwtProvider;
    private readonly IUserRepository _userRepository;
    private readonly IFileStorerProvider _fileStorerProvider;

    public RegisterUserCommandHandler(UserManager<AppUser> userManager, IJWTProvider jwtProvider, IUserRepository userRepository, IFileStorerProvider fileStorerProvider)
    {
        _userManager = userManager;
        _jwtProvider = jwtProvider;
        _userRepository = userRepository;
        _fileStorerProvider = fileStorerProvider;
    }

    public async Task<AuthResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var userDb = await _userRepository.FindByEmailAsync(request.Email);

        if (userDb is not null)
            throw new UserWithPropertyAlreadyExistsException(
                $"Un usuario con {nameof(request.Email)} - {request.Email} ya se encuentra registrado en la plataforma.");

        var pictureURL = await _fileStorerProvider.UploadImageAsync(request.ProfilePicture);

        var user = AppUser.Create(request.FirstName, request.SecondName,
                                request.LastName, request.SecondLastName
                                , request.Email, request.Password, request.Age,
                                request.PhoneNumber, request.Gender, pictureURL);

        await _userManager.CreateAsync(user, request.Password);

        var token = _jwtProvider.Create(user);

        user = await _userRepository.FindByEmailAsync(user.Email);

        var response = user.ToUserResponse();
        
        return new AuthResponse(token, response);
    }
}


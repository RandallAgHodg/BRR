using BRR.Application.Abstractions.Authentication;
using BRR.Application.Abstractions.Messaging;
using BRR.Application.Core.Exceptions.User;
using BRR.Contracts.Users;
using BRR.Domain.Entities;
using BRR.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BRR.Application.Users.Commands;

public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, AuthResponse>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IJWTProvider _jwtProvider;
    private readonly IUserRepository _userRepository;

    public RegisterUserCommandHandler(UserManager<AppUser> userManager, IJWTProvider jwtProvider, IUserRepository userRepository)
    {
        _userManager = userManager;
        _jwtProvider = jwtProvider;
        _userRepository = userRepository;
    }

    public async Task<AuthResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var userDb = await _userRepository.FindByEmailAsync(request.Email);

        if (userDb is not null)
            throw new UserWithPropertyAlreadyExistsException(
                $"Un usuario con {nameof(request.Email)} - {request.Email} ya se encuentra registrado en la plataforma.");

        var user = AppUser.Create(request.FirstName, request.SecondName,
                                request.LastName, request.SecondLastName
                                ,request.Email, request.Password, request.Age,
                                request.PhoneNumber, request.Gender);

        var result= await _userManager.CreateAsync(user, request.Password);

        var token = _jwtProvider.Create(user);

        user = await _userRepository.FindByEmailAsync(user.Email);
        
        return new AuthResponse(token, user);
    }
}


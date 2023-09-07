using BRR.Application.Abstractions.Authentication;
using BRR.Application.Abstractions.FileStorer;
using BRR.Application.Abstractions.Messaging;
using BRR.Application.Auth.Register;
using BRR.Application.Core.Exceptions.User;
using BRR.Contracts.Responses.Users;
using BRR.Domain.Entities;
using BRR.Domain.Repositories;
using BRR.Domain.UOW;
using BRR.WebAPI.Mapping;
using Microsoft.AspNetCore.Identity;

public sealed class RegisterAgentCommandHandler : ICommandHandler<RegisterAgentCommand, AuthResponse>
{
    private readonly UserManager<Account> _userManager;
    private readonly IFileStorerProvider _fileStorerProvider;
    private readonly IJWTProvider _jwtProvider;
    private readonly IAgentRepository _agentRepository;
    private readonly IUnitOfWork _unitOfWork;
    public RegisterAgentCommandHandler(UserManager<Account> userManager, IFileStorerProvider fileStorerProvider, IJWTProvider jwtProvider, IAgentRepository agentRepository, IUnitOfWork unitOfWork)
    {
        _userManager = userManager;
        _fileStorerProvider = fileStorerProvider;
        _jwtProvider = jwtProvider;
        _agentRepository = agentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<AuthResponse> Handle(RegisterAgentCommand request, CancellationToken cancellationToken)
    {
        var pictureUrl = await _fileStorerProvider.UploadImageAsync(request.ProfilePicture);

        var account = Account.Create(request.FirstName, request.LastName, request.Email, request.PhoneNumber, pictureUrl, Role.AgentRole);

        var result = await _userManager.CreateAsync(account, request.Password);

        var agent = await _agentRepository.FindByEmailAsync(request.Email);

        if (agent is not null)
            throw new UserWithPropertyAlreadyExistsException("Ya se encuentra un usuario con ese correo en el sistema.");

        if(result.Succeeded)
        {
            var userAccount = await _userManager.FindByEmailAsync(request.Email);

            userAccount.AddAgent();

            var token = _jwtProvider.Create(userAccount);

            var agentDb = Agent.Create(account);

            await _unitOfWork.SaveChangesAsync();

            var response = account.ToResponse();

            return new AuthResponse(token, response);
        }

        throw new InvalidRegisterAttemptException();
    }
}
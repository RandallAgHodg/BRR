//using BRR.Application.Abstractions.Authentication;
//using BRR.Application.Abstractions.Messaging;
//using BRR.Application.Core.Exceptions.User;
//using BRR.Contracts.Responses.Users;
//using BRR.Domain.Repositories;
//using Mapster;

//namespace BRR.Application.Auth.Login;

//public sealed class LoginCommandHandler : ICommandHandler<LoginCommand, AuthResponse>
//{
//    private readonly IAgentRepository _agentRepository;
//    private readonly IClientRepository _clientRepository;
//    private readonly IJWTProvider _JWTProvider;

//    public LoginCommandHandler(IAgentRepository agentRepository, IClientRepository clientRepository, IJWTProvider jWTProvider)
//    {
//        _agentRepository = agentRepository;
//        _clientRepository = clientRepository;
//        _JWTProvider = jWTProvider;
//    }

//    public async Task<AuthResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
//    {
//        var agent = _agentRepository.FindByEmailAsync(request.Email);

//        var client = _clientRepository.FindByEmailAsync(request.Email);

//        if (agent is null && client is null)
//            throw new InvalidUserLoginException("Credenciales invalidas.");

//        if(agent is null)
//        {
//            var clientLogged = await _clientRepository.LoginAsync(request.Email, request.Password);

//            if (clientLogged is null)
//                throw new InvalidUserLoginException("Credenciales invalidas.");

//            var token = _JWTProvider.Create(clientLogged.Id, clientLogged.Email, clientLogged.Role.Name);

//            var response = clientLogged.Adapt<UserReponse>();

//            return new AuthResponse(token, response);
//        }
//        else
//        {
//            var agentLogged = await _agentRepository.LoginAsync(request.Email, request.Password);

//            if (agentLogged is null)
//                throw new InvalidUserLoginException("Credenciales invalidas.");

//            var token = _JWTProvider.Create(agentLogged.Id, agentLogged.Email, agentLogged.Role.Name);

//            var response = agentLogged.Adapt<UserReponse>();

//            return new AuthResponse(token, response);
//        }
//    }
//}

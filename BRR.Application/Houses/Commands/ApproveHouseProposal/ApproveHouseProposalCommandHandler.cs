using BRR.Application.Abstractions.Authentication;
using BRR.Application.Abstractions.Messaging;
using BRR.Application.Core.Exceptions.Houses;
using BRR.Application.Core.Exceptions.User;
using BRR.Application.Mapping;
using BRR.Contracts.Responses.Houses;
using BRR.Domain.Repositories;
using BRR.Domain.UOW;

namespace BRR.Application.Houses.Commands.ApproveHouseProposal;

public sealed class ApproveHouseProposalCommandHandler : ICommandHandler<ApproveHouseProposalCommand, HouseResponseWithAgent>
{
    private readonly IUserRepository _userRepository;
    private readonly IHouseRepository _houseRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserInformationProvider _userInformationProvider;

    public ApproveHouseProposalCommandHandler(IUserRepository userRepository, IHouseRepository houseRepository, IUnitOfWork unitOfWork, IUserInformationProvider userInformationProvider)
    {
        _userRepository = userRepository;
        _houseRepository = houseRepository;
        _unitOfWork = unitOfWork;
        _userInformationProvider = userInformationProvider;
    }

    public async Task<HouseResponseWithAgent> Handle(ApproveHouseProposalCommand request, CancellationToken cancellationToken)
    {
        var loggedUserId = _userInformationProvider.UserId;

        if (loggedUserId is 0)
            throw new CouldntRetrieveLoggedUserInformationException("No se pudo recuperar la informacion del usuario con sesion activa.");

        var agent = await _userRepository.FindByIdAsync(loggedUserId);

        if (agent is null)
            throw new UserNotFoundException(
                "La informacion del agente no pudo ser recuperada. Intentelo nuevamente");
        
        if (!agent.IsAgent)
            throw new OnlyAgentsCanApproveHousesProposalsException("No puede aprobar una solicitud de registro de casa si no es agente.");

        var client = await _userRepository.FindByIdAsync(request.clientId);

        if (client is null)
            throw new UserNotFoundException(
                "La informacion del cliente no pudo ser recuperada. Intentelo nuevamente");

        var house = await _houseRepository.FindByIdAsync(request.houseId);

        if (house is null)
            throw new HouseNotFoundException(
                "La informacion de la casa no pudo ser recuperada. Intentelo nuevamente");

        house.Accept();

        client.SetAgent(agent);

        agent.AddClient(client);

        await _unitOfWork.SaveChangesAsync();

        var response = house.ToHouseResponseWithAgent(agent);

        return response;
    }
}

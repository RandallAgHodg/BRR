using BRR.Application.Abstractions.Authentication;
using BRR.Application.Abstractions.Messaging;
using BRR.Application.Core.Exceptions.Houses;
using BRR.Application.Core.Exceptions.User;
using BRR.Contracts.Responses;
using BRR.Domain.Repositories;
using BRR.Domain.UOW;

namespace BRR.Application.Houses.Commands.DeleteHouse;

public sealed class DeleteHouseCommandHandler : ICommandHandler<DeleteHouseCommand, DeleteHouseResponse>
{
    private readonly IHouseRepository _houseRepository;
    private readonly IUserInformationProvider _userInformationProvider;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteHouseCommandHandler(IHouseRepository houseRepository, IUserRepository userRepository, IUserInformationProvider userInformationProvider, IUnitOfWork unitOfWork)
    {
        _houseRepository = houseRepository;
        _userRepository = userRepository;
        _userInformationProvider = userInformationProvider;
        _unitOfWork = unitOfWork;
    }

    public async Task<DeleteHouseResponse> Handle(DeleteHouseCommand request, CancellationToken cancellationToken)
    {
        var loggedUserId = _userInformationProvider.UserId;

        if (loggedUserId is 0)
            throw new CouldntRetrieveLoggedUserInformationException(
                "No se pudo recuperar la informacion del usuario con sesion activa. Intentelo nuevamente.");

        var agent = await _userRepository.FindByIdAsync(loggedUserId);

        if (agent is null)
            throw new UserNotFoundException("No se pudo recuperar la informacion del agente.");

        if (!agent.IsAgent)
            throw new OnlyAgentsCanDeleteHousesException("Solo los usuarios del tipo agente pueden eliminar casas del sistema.");

        var house = await _houseRepository.FindByIdAsync(request.houseId);

        if (house is null)
            throw new HouseNotFoundException("No se pudo recuperar la informacion de la casa.");

        house.Delete();

        await _unitOfWork.SaveChangesAsync();

        return new DeleteHouseResponse("La casa fue eliminada del sistema.");
    }
}

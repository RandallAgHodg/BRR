using BRR.Application.Abstractions.Authentication;
using BRR.Application.Abstractions.Messaging;
using BRR.Application.Core.Exceptions.Houses;
using BRR.Application.Core.Exceptions.User;
using BRR.Contracts.Responses.Houses;
using BRR.Domain.Repositories;
using BRR.Domain.UOW;

namespace BRR.Application.Houses.Commands.RejectHouseProposal;

public sealed class RejectHouseProposalCommandHandler : ICommandHandler<RejectHouseProposalCommand, RejectHouseResponse>
{
    private readonly IUserInformationProvider _userInformationProvider;
    private readonly IHouseRepository _houseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RejectHouseProposalCommandHandler(IUserInformationProvider userInformationProvider, IHouseRepository houseRepository, IUnitOfWork unitOfWork)
    {
        _userInformationProvider = userInformationProvider;
        _houseRepository = houseRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<RejectHouseResponse> Handle(RejectHouseProposalCommand request, CancellationToken cancellationToken)
    {
        var loggedUserId = _userInformationProvider.UserId;

        if(loggedUserId is 0)
            throw new CouldntRetrieveLoggedUserInformationException(
                "No se pudo recuperar la informacion del usuario con sesion activa. Intentelo nuevamente.");

        var house = await _houseRepository.FindByIdAsync(request.houseId);

        if (house is null)
            throw new HouseNotFoundException("La informacion de la casa no pudo der recuperada. Intentelo nuevamente.");

        house.Reject();

        await _unitOfWork.SaveChangesAsync();

        return new RejectHouseResponse
        {
            Message = "La propuesta ha sido rechazada."
        };
    }
}

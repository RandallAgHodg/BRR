using BRR.Application.Abstractions.Authentication;
using BRR.Application.Abstractions.FileStorer;
using BRR.Application.Abstractions.Messaging;
using BRR.Application.Core.Exceptions.Houses;
using BRR.Application.Core.Exceptions.User;
using BRR.Application.Mapping;
using BRR.Contracts.Responses.Houses;
using BRR.Domain.Repositories;
using BRR.Domain.UOW;

namespace BRR.Application.Houses.Commands.UpdateHouseInformation;

public sealed class UpdateHouseInformationCommandHandler : ICommandHandler<UpdateHouseCommand, HouseResponse>
{
    private readonly IHouseRepository _houseRepository;
    private readonly IUserInformationProvider _userInformationProvider;
    private readonly IUserRepository _userRepository;
    private readonly IFileStorerProvider _fileStorerProvider;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateHouseInformationCommandHandler(IHouseRepository houseRepository, IUserInformationProvider userInformationProvider, IUserRepository userRepository, IFileStorerProvider fileStorerProvider, IUnitOfWork unitOfWork)
    {
        _houseRepository = houseRepository;
        _userInformationProvider = userInformationProvider;
        _userRepository = userRepository;
        _fileStorerProvider = fileStorerProvider;
        _unitOfWork = unitOfWork;
    }

    public async Task<HouseResponse> Handle(UpdateHouseCommand request, CancellationToken cancellationToken)
    {
        var loggedUserId = _userInformationProvider.UserId;

        if (loggedUserId is 0)
            throw new CouldntRetrieveLoggedUserInformationException(
                "No se pudo recuperar la informacion del usuario con sesion activa. Intentelo nuevamente.");
    
        var agent = await _userRepository.FindByIdAsync(loggedUserId);

        if (agent is null)
            throw new UserNotFoundException(
                "No se pudo recuperar la informacion del agente. Intentelo nuevamente");

        var house = await _houseRepository.FindByIdAsync(request.Id);

        if (house is null)
            throw new HouseNotFoundException("No se pudo recuperar la informacion del inmueble. Intentlo nuevamente.");

        string pictureUrl = string.Empty;

        if(request.Picture is not null)
            pictureUrl = await _fileStorerProvider.UploadImageAsync(request.Picture);

        string videoUrl = string.Empty;

        if (request.Video is not null)
            videoUrl = await _fileStorerProvider.UploadVideoAsync(request.Video);

        house.UpdateInformation(request.ToDomain(pictureUrl, videoUrl));

        await _unitOfWork.SaveChangesAsync();

        var response = house.ToHouseResponse();

        return response;
    }
}

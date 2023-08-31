using BRR.Application.Abstractions.Authentication;
using BRR.Application.Abstractions.FileStorer;
using BRR.Application.Abstractions.Messaging;
using BRR.Application.Core.Exceptions.User;
using BRR.Application.Mapping;
using BRR.Contracts.Responses.Houses;
using BRR.Domain.Entities;
using BRR.Domain.Repositories;
using BRR.Domain.UOW;

namespace BRR.Application.Houses.Commands.SendHouseProposal;

public sealed class SendHousesProposalCommandHandler : ICommandHandler<SendHouseProposalCommand, HouseResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IFileStorerProvider _fileStorerProvider;
    private readonly IUserInformationProvider _userInformationProvider;
    private readonly IHouseRepository _houseRepository;

    public SendHousesProposalCommandHandler(IUnitOfWork unitOfWork, IFileStorerProvider fileStorerProvider, IUserInformationProvider userInformationProvider, IHouseRepository houseRepository, IUserRepository userRepository)
    {
        _unitOfWork = unitOfWork;
        _fileStorerProvider = fileStorerProvider;
        _userInformationProvider = userInformationProvider;
        _houseRepository = houseRepository;
        _userRepository = userRepository;
    }

    public async Task<HouseResponse> Handle(SendHouseProposalCommand request, CancellationToken cancellationToken)
    {
        var loggedUserId = _userInformationProvider.UserId;

        var client = await _userRepository.FindByIdAsync(loggedUserId);

        if (client is null)
            throw new UserNotFoundException(
                "La informacion del usuario no pudo ser recuperada exitosamente");



        var imageUrl = await _fileStorerProvider.UploadImageAsync(request.Picture);

        var videoUrl = await _fileStorerProvider.UploadVideoAsync(request.Video);

        var house = House.Create(imageUrl, videoUrl, request.title, request.area,
                                request.address, request.price, request.discount,
                                request.bedrooms, request.bathrooms, request.livingrooms,
                                request.floors, request.hasPool, request.hasBalcony);


        await _houseRepository.AddAsync(house);

        house.SetClient(client);

        await _unitOfWork.SaveChangesAsync();

        var response = house.ToHouseResponse();

        return response;
    }
}

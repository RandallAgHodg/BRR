//using BRR.Application.Abstractions.Authentication;
//using BRR.Application.Abstractions.Messaging;
//using BRR.Application.Core.Exceptions.Houses;
//using BRR.Application.Core.Exceptions.User;
//using BRR.Contracts.Responses.Meetings;
//using BRR.Domain.Entities;
//using BRR.Domain.Repositories;
//using BRR.Domain.UOW;

//namespace BRR.Application.Meetings.AgendMeeting;

//public sealed class AgendMeetingCommandHandler : ICommandHandler<AgendMeetingCommand, MeetingResponse>
//{
//    private readonly IUserInformationProvider _userInformationProvider;
//    private readonly IMeetingRepository _meetingRepository;
//    private readonly IUnitOfWork _unitOfWork;
//    private readonly IHouseRepository _houseRepository;
//    private readonly IUserRepository _userRepository;
//    public AgendMeetingCommandHandler(IUserInformationProvider userInformationProvider, IMeetingRepository meetingRepository, IUnitOfWork unitOfWork, IHouseRepository houseRepository, IUserRepository userRepository)
//    {
//        _userInformationProvider = userInformationProvider;
//        _meetingRepository = meetingRepository;
//        _unitOfWork = unitOfWork;
//        _houseRepository = houseRepository;
//        _userRepository = userRepository;
//    }

//    public async Task<MeetingResponse> Handle(AgendMeetingCommand request, CancellationToken cancellationToken)
//    {
//        var loggedUserId = _userInformationProvider.UserId;

//        if (loggedUserId is 0)
//            throw new CouldntRetrieveLoggedUserInformationException("No se pudo recuperar la informacion del cliente registrado. Intentelo nuevamente");

//        var house = await _houseRepository.FindByIdAsync(request.houseId);

//        if (house is null)
//            throw new HouseNotFoundException("No se pudo recuperar la informacion de la casa");

//        var agent = await _userRepository.GetClientAgentAsync(loggedUserId);

//        if(agent is null)
//        var meeting = Meeting.Create(request.message, request.houseId, request.agen)
//    }
//}

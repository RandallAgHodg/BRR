using BRR.Application.Abstractions.Messaging;
using BRR.Contracts.Responses.Meetings;

namespace BRR.Application.Meetings.AgendMeeting;

public sealed record AgendMeetingCommand (int houseId, 
    string message, 
    DateTime Date): ICommand<MeetingResponse>;

namespace BRR.Contracts.Requests.Meetings;

public sealed record MeetingRequest (string message, int houseId, DateTime date);


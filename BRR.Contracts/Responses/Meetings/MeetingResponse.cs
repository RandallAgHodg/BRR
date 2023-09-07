namespace BRR.Contracts.Responses.Meetings;

public sealed record MeetingResponse (int houseId, int clientId, string message, DateTime date);

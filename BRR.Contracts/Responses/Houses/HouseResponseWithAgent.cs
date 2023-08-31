using BRR.Contracts.Responses.Users;

namespace BRR.Contracts.Responses.Houses;

public sealed record HouseResponseWithAgent(
    int id,
    string title,
    string address,
    decimal area,
    decimal price,
    int discount,
    int bedrooms,
    int bathrooms,
    int livingrooms,
    int floors,
    bool hasPool,
    bool hasBalcony,
    bool isSold,
    bool isAccepted,
    string pictureUrl,
    string VideoUrl,
    UserReponse client,
    UserReponse? agent
    );

using BRR.Contracts.Responses.Users;
using CloudinaryDotNet.Actions;

namespace BRR.Contracts.Responses.Houses;

public sealed record HouseResponse(
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
    UserReponse client
    );

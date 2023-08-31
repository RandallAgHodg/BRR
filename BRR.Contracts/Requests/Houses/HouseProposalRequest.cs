namespace BRR.Contracts.Requests.Houses;

public class HouseProposalRequest
{
    public string Title { get; init; }
    public string Address { get; init; }
    public decimal Area { get; init; }
    public decimal Price { get; init; }
    public int Discount { get; init; }
    public int Bedrooms { get; init; }
    public int Bathrooms { get; init; }
    public int Livingrooms { get; init; } 
    public int Floors { get; init; }
    public bool HasPool { get; init; }
    public bool HasBalcony { get; init; }
}

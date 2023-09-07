using System.Diagnostics;
using System.Net;

namespace BRR.Domain.Entities;

public sealed class House
{
    private HashSet<Meeting> _meetings { get; set; } = new();
    private House()
    {
    }

    public static House Create(string pictureUrl, string videoUrl, string title, 
        decimal area, string address, decimal price, 
        int discount, int bedrooms, 
        int bathrooms, int livingrooms, 
        int floors, bool hasPool, bool hasBalcony)
    {
        return new House
        {
            PictureUrl = pictureUrl,
            VideoUrl = videoUrl,
            Title = title,
            Area = area,
            Price = price,
            Discount = discount,
            Bedrooms = bedrooms,
            Bathrooms = bathrooms,
            Livingrooms = livingrooms,
            Floors = floors,
            HasPool = hasPool,
            HasBalcony = hasBalcony,
            Address = address
        };
    }

    public static House Create(int id, string pictureUrl, string videoUrl, string title,
        decimal area, string address, decimal price,
        int discount, int bedrooms,
        int bathrooms, int livingrooms,
        int floors, bool hasPool, bool hasBalcony)
    {
        return new House
        {
            PictureUrl = pictureUrl,
            VideoUrl = videoUrl,
            Title = title,
            Area = area,
            Price = price,
            Discount = discount,
            Bedrooms = bedrooms,
            Bathrooms = bathrooms,
            Livingrooms = livingrooms,
            Floors = floors,
            HasPool = hasPool,
            HasBalcony = hasBalcony,
            Address = address
        };
    }

    public void Accept ()
    {
        IsAccepted = true;
        IsRejected = false;
    }
    public void Reject()
    {
        IsAccepted = false;
        IsRejected = true;
    }
    public void SetClient(Client client)
    {
        ClientId = client.Id;
        Client = client;
    }
    public void Delete () => IsDeleted = true;
    public void UpdateInformation(House house)
    {
        Id = house.Id;
        PictureUrl = house.PictureUrl;
        VideoUrl = house.VideoUrl;
        Title = house.Title;
        Area = house.Area;
        Price = house.Price;
        Discount = house.Discount;
        Bedrooms = house.Bedrooms;
        Bathrooms = house.Bathrooms;
        Livingrooms = house.Livingrooms;
        Floors = house.Floors;
        HasPool = house.HasPool;
        HasBalcony = house.HasBalcony;
        Address = house.Address;
    }

    public int Id { get; private set; }
    public string PictureUrl { get; private set; }
    public string VideoUrl { get; private set; }
    public string Title { get; private set; }
    public decimal Area { get; private set; }
    public string Address { get; private set; }
    public decimal Price { get; private set; }
    public int Discount { get; private set; }
    public int Bedrooms { get; private set; }
    public int Bathrooms { get; private set; }
    public int Livingrooms { get; private set; }
    public int Floors { get; private set; }
    public bool HasPool { get; private set; }
    public bool HasBalcony { get; private set; }
    public bool IsSold { get; private set; }
    public bool IsAccepted { get; private set; }
    public bool IsRejected { get; private set; }
    public Client Client { get; private set; }
    public int ClientId { get; private set; }
    public int HouseTypeId { get; private set; }
    public HouseType HouseType { get; set; }
    public IReadOnlyCollection<Meeting> Meetings => _meetings.ToList();
    public bool IsDeleted { get; private set; }
}

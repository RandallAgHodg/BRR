using BRR.Application.Houses.Commands.ApproveHouseProposal;
using BRR.Application.Houses.Commands.SendHouseProposal;
using BRR.Application.Houses.Queries.GetTop5Houses;
using BRR.Application.Houses.Queries.SearchHouses;
using BRR.Contracts.Requests.Houses;
using BRR.WebAPI.Extensions;
using BRR.WebAPI.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BRR.WebAPI.Controllers;

[ApiController]
public class HousesController : ControllerBase
{
    private readonly IMediator _mediatr;

    public HousesController(IMediator mediatr) =>
        _mediatr = mediatr;
    

    [HttpPost(ApiRoutes.Houses.SendHouseProposal)]
    [Authorize]
    public async Task<IActionResult> SendHouseProposal([FromForm] CreateHouseRequest request)
    {
        var command = new SendHouseProposalCommand(request.Title, request.Address, request.Area,
                                                   request.Price, request.Discount, request.Bedrooms,
                                                   request.Bathrooms, request.Livingrooms, request.Floors,
                                                   request.Picture.ToImageUploadParams(), request.Video.ToVideoUploadParams());
    
        var result = await _mediatr.Send(command);  

        return Ok(result);  
    }

    [HttpPost(ApiRoutes.Houses.ApproveHouseProposal)]
    [Authorize]
    public async Task<IActionResult> ApproveHouseProposal([FromQuery] ApproveHouseRequest request)
    {
        var command = new ApproveHouseProposalCommand(request.houseId, request.clientId);

        var result = await _mediatr.Send(command);

        return Ok(result);
    }

    [HttpGet(ApiRoutes.Houses.GetTop5HousesByDiscount)]
    [AllowAnonymous]
    public async Task<IActionResult> GetTop5HousesByDiscount() =>
        Ok(await _mediatr.Send(new GetTop5HousesByDiscountQuery()));

    [HttpGet(ApiRoutes.Houses.SearchHouses)]
    public async Task<IActionResult> SearchHouses([FromQuery] SearchHousesFilterRequest request)
    {
        var query = new SearchHousesQuery(request.querySearch, request.price, request.livingrooms,
            request.floors, request.bathrooms, request.hasBalcony, 
            request.hasDiscount, request.hasPool);

        var result = await _mediatr.Send(query);

        return Ok(result);  
    }
}

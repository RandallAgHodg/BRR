using BRR.Application.Houses.Commands.ApproveHouseProposal;
using BRR.Application.Houses.Commands.DeleteHouse;
using BRR.Application.Houses.Commands.RejectHouseProposal;
using BRR.Application.Houses.Commands.SendHouseProposal;
using BRR.Application.Houses.Commands.UpdateHouseInformation;
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

    [HttpPut(ApiRoutes.Houses.UpdateHouseInformation)]
    public async Task<IActionResult> Update([FromQuery] int userId, [FromBody] UpdateHouseInformationRequest request)
    {
        var command = new UpdateHouseInformationCommand(userId, request.Title, request.Address,
            request.Area, request.Price, request.Discount, request.Bedrooms, request.Bathrooms,
            request.Livingrooms,request.Floors, request.Picture.ToImageUploadParams(), 
            request.Picture.ToVideoUploadParams(), request.HasPool, request.HasBalcony);

        var result = await _mediatr.Send(command);

        return Ok(result);  
    }

    [HttpPost(ApiRoutes.Houses.RejectHouse)]
    public async Task<IActionResult> Reject([FromQuery] int houseId)
    {
        var command = new RejectHouseProposalCommand(houseId);

        var result = await _mediatr.Send(command);

        return Ok(result);
    }

    [HttpDelete(ApiRoutes.Houses.DeleteHouse)]
    public async Task<IActionResult> Delete([FromQuery] int houseId)
    {
        var command = new DeleteHouseCommand(houseId);

        var result = await _mediatr.Send(command);

        return Ok(result);
    }
}

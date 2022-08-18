using API.ApiModels;
using Application.Features.AddInformation;
using Application.Features.GetAllInfoInCategoryQuery;
using Application.Features.GetInfo;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AddInfoRequest = Application.Features.AddInformation.AddInfoRequest;

namespace API.Controllers;

[ApiController]
[Route("/api/info/")]
public class InformationController : ControllerBase
{
    private readonly IMediator _mediator;

    public InformationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("add-info")]
    public async Task<IActionResult> AddInfo(AddInfoRequest request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }
    
    [HttpGet("get-all-info-in-category")]
    public async Task<IActionResult> GetAllInfoInCategory(string categoryName)
    {
        var result = await _mediator.Send(new GetAllInfoInCategoryRequest{CategoryName = categoryName});
        return Ok(result);
    }
    
    [HttpGet("get-info")]
    public async Task<IActionResult> GetInfo(int id)
    {
        var result = await _mediator.Send(new GetInfoRequest(){Id = id});
        return Ok(result);
    }
}
using System.Net;
using EcommerDiscountSystem.Dtos;
using EcommerDiscountSystem.Features.Commands.Discount;
using EcommerDiscountSystem.Features.Queries.Discount;
using EcommerDiscountSystem.Helpers;
using EcommerDiscountSystem.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EcommerDiscountSystem.Controllers;

public class DiscountsController:BaseController
{
    private readonly IMediator _mediator;

    public DiscountsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<DiscountDto>), (int) HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ExceptionDto), (int) HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetDiscounts() => Ok(await _mediator.Send(new GetAllDiscountQuery()));
    
    [HttpGet("active")]
    [ProducesResponseType(typeof(List<DiscountDto>), (int) HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ExceptionDto), (int) HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetActiveDiscounts() => Ok(await _mediator.Send(new GetAllActiveDiscountQueries()));
    
    [HttpPost]
    [ProducesResponseType(typeof(DiscountDto), (int) HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ExceptionDto), (int) HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ExceptionDto), (int) HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> CreateDiscount([FromBody] CreateDiscountDto discountDto) => Ok(await _mediator.Send(new CreateDiscountCommand(discountDto)));
    
    [HttpPut]
    [ProducesResponseType(typeof(DiscountDto), (int) HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ExceptionDto), (int) HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ExceptionDto), (int) HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> UpdateDiscount([FromBody] DiscountDto discountDto) => Ok(await _mediator.Send(new UpdateDiscountCommand(discountDto)));
    
}
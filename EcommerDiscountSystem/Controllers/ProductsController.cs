using System.Net;
using EcommerDiscountSystem.Dtos;
using EcommerDiscountSystem.Features.Queries.Product;
using EcommerDiscountSystem.Helpers;
using EcommerDiscountSystem.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EcommerDiscountSystem.Controllers;

public class ProductsController : BaseController
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<ProductDto>), (int) HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ExceptionDto), (int) HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetProducts() => Ok(await _mediator.Send(new GetAllProductQuery()));
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ProductDto), (int) HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ExceptionDto), (int) HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetProduct(string id) => Ok(await _mediator.Send(new GetProductByIdQuery(id)));
}
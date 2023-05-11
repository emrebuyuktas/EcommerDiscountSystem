using System.Net;
using EcommerDiscountSystem.Dtos;
using EcommerDiscountSystem.Features.Queries.Category;
using EcommerDiscountSystem.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EcommerDiscountSystem.Controllers;

public class CategoriesController:BaseController
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<CategoryDto>), (int) HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ExceptionDto), (int) HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetCategories() => Ok(await _mediator.Send(new GetAllCategoriesQuery()));
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(CategoryDto), (int) HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ExceptionDto), (int) HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetCategoryById(string id) => Ok(await _mediator.Send(new GetCategoryByIdQuery(id)));
}
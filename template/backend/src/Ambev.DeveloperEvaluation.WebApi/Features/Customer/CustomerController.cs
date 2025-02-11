using Ambev.DeveloperEvaluation.Application.Customer.CreateCustomer;
using Ambev.DeveloperEvaluation.Application.Customer.ListCustomer;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Customer.CreateCustomer;
using Ambev.DeveloperEvaluation.WebApi.Features.Customer.ListCustomer;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customer;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public CustomerController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }


    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateCustomerResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateCustomerValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateCustomerCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CreateCustomerResponse>
        {
            Success = true,
            Message = "Customer created successfully",
            Data = _mapper.Map<CreateCustomerResponse>(response)
        });
    }

    [HttpGet]
    [ProducesResponseType(typeof(ApiResponseWithData<PaginatedList<ListCustomerResponse>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ListCustomer(
        [FromQuery] int _page = 1,
        [FromQuery] int _size = 10,
        [FromQuery] string? _order = null)
    {


        var ListProductResult = await _mediator.Send(new ListCustomerCommand());
        var response = _mapper.Map<List<ListCustomerResponse>>(ListProductResult);

        return Ok(new ApiResponseWithData<PaginatedList<ListCustomerResponse>>
        {
            Success = true,
            Message = "",
            Data = new PaginatedList<ListCustomerResponse>(response, response.Count, _page, _size)
        });
    }
}

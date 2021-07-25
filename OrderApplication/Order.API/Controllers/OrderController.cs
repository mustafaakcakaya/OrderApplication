using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Application.Features.Commands.ChangeStatus;
using Order.Application.Features.Commands.CreateOrder;
using Order.Application.Features.Commands.DeleteOrder;
using Order.Application.Features.Commands.UpdateOrder;
using Order.Application.Features.Queries.GetOrder;
using Order.Application.Features.Queries.GetOrders;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Order.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        //TODO: testing purpose
        [HttpPost("[action]", Name = "Create")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> Create([FromBody] CreateOrderCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("[action]", Name = "Update")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<ActionResult> Update([FromBody] UpdateOrderCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("[action]/{id}", Name = "Delete")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<ActionResult> Delete(string id)
        {
            var command = new DeleteOrderCommand() { Id = id };
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("[action]", Name = "Get")]
        [ProducesResponseType(typeof(List<CommonLibrary.Entities.Order>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CommonLibrary.Entities.Order>>> Get()
        {
            var query = new GetOrdersQuery();
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }

        [HttpGet("[action]/{id}", Name = "GetById")]
        [ProducesResponseType(typeof(CommonLibrary.Entities.Order), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetById(string id)
        {
            var command = new GetOrderQuery() { Id = id };
            var order = await _mediator.Send(command);
            return Ok(order);
        }

        [HttpPost("[action]", Name = "ChangeStatus")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<ActionResult> ChangeStatus([FromBody] ChangeStatusCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

    }
}

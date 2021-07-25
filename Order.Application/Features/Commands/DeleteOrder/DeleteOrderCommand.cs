using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Application.Features.Commands.DeleteOrder
{
    public class DeleteOrderCommand : IRequest<bool>
    {
        public string Id { get; set; }
    }
}

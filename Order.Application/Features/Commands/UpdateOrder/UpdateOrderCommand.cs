using CommonLibrary.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Application.Features.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest<bool>
    {
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }
        public string Status { get; set; }
        public Address Address { get; set; }
        public Product Product { get; set; }
    }
}

using CommonLibrary.Entities;
using CommonLibrary.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Application.Features.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<string>
    {
        public string CustomerId { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }
        public string Status { get; set; }
        public Address Address { get; set; }
        public Product Product { get; set; }
    }
}

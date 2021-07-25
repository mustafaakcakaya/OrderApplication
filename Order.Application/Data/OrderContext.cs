using CommonLibrary.Context;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Application.Data
{
    public class OrderContext : BaseContext<CommonLibrary.Entities.Order>
    {
        public OrderContext(IConfiguration configuration) : base(configuration)
        {
            OrderContextSeed.SeedData(Entities);
        }

    }
}

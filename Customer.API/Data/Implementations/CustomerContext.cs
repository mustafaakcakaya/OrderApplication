using CommonLibrary.Context;
using Customer.API.Data.Interfaces;
using Customer.API.Data.Seed;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.API.Data.Implementations
{
    public class CustomerContext : BaseContext<Entities.Customer>, ICustomerContext
    {
        public CustomerContext(IConfiguration configuration) : base(configuration)
        {
            CustomerContextSeed.SeedData(Entities);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Customer.API.Data.Interfaces
{
    public interface ICustomerContext
    {
        IMongoCollection<Entities.Customer> Entities { get; }
    }
}

using CommonLibrary.Entities;
using CommonLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Order.Application.Repository
{
    public interface IOrderRepository : IBaseRepository<CommonLibrary.Entities.Order> 
    {
        Task<bool> ChangeStatus(string id, string status);
    }
}

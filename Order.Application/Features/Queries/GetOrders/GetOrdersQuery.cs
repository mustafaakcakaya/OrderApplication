using MediatR;
using System.Collections.Generic;

namespace Order.Application.Features.Queries.GetOrders
{
    public class GetOrdersQuery : IRequest<List<CommonLibrary.Entities.Order>>
    {
        public string Id { get; set; }

        public GetOrdersQuery(string id = null)
        {
            Id = id;
        }
    }
}

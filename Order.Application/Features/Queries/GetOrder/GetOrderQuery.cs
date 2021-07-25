using MediatR;
using System.Collections.Generic;

namespace Order.Application.Features.Queries.GetOrder
{
    public class GetOrderQuery : IRequest<CommonLibrary.Entities.Order>
    {
        public string Id { get; set; }

        public GetOrderQuery(string id = null)
        {
            Id = id;
        }
    }
}

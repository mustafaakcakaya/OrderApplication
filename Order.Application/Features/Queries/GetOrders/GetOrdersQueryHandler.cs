using AutoMapper;
using MediatR;
using Order.Application.Repository;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Order.Application.Features.Queries.GetOrders
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, List<CommonLibrary.Entities.Order>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrdersQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }

        public async Task<List<CommonLibrary.Entities.Order>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetAllAsync();
        }

    }
}

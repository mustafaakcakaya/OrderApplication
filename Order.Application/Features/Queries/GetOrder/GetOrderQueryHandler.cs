using MediatR;
using Order.Application.Repository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Order.Application.Features.Queries.GetOrder
{
    class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, CommonLibrary.Entities.Order>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }

        public async Task<CommonLibrary.Entities.Order> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetByIdAsync(request.Id);
        }
    }
}

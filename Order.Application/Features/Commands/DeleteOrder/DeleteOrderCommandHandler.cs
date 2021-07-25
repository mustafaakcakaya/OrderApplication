using MediatR;
using Order.Application.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Order.Application.Features.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, bool>
    {
        private readonly IOrderRepository _orderRepository;
        public DeleteOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }

        public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var isDeleted = await _orderRepository.DeleteAsync(request.Id);

            return isDeleted;
        }

    }
}

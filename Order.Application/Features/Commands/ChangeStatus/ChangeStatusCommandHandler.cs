using MediatR;
using Order.Application.Repository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Order.Application.Features.Commands.ChangeStatus
{
    public class ChangeStatusCommandHandler : IRequestHandler<ChangeStatusCommand, bool>
    {
        private readonly IOrderRepository _orderRepository;

        public ChangeStatusCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }

        public async Task<bool> Handle(ChangeStatusCommand request, CancellationToken cancellationToken)
        {
            var orderToUpdate = await _orderRepository.GetByIdAsync(request.Id);
            if (orderToUpdate == null)
                return false;

            orderToUpdate.Status = request.Status;

            return await _orderRepository.UpdateAsync(orderToUpdate);
        }
    }
}

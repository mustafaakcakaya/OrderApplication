using AutoMapper;
using MediatR;
using Order.Application.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Order.Application.Features.Commands.CreateOrder
{
    class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, string>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<string> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var orderEntity = _mapper.Map<CommonLibrary.Entities.Order>(request);
            var orderId = await _orderRepository.AddAsync(orderEntity);

            return orderId;
        }
    }
}

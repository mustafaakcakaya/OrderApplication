using MediatR;

namespace Order.Application.Features.Commands.ChangeStatus
{
    public class ChangeStatusCommand : IRequest<bool>
    {
        public string Id { get; set; }
        public string Status { get; set; }

    }
}

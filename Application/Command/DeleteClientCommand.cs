using Application.PipilineBehavior;
using Domain.Entities.Dtos;
using MediatR;

namespace Application.Command
{
    public class DeleteClientCommand : IRequest<Response>
    {
        public DeleteClientCommand(int clientId)
        {
            ClientId = clientId;
        }

        public int ClientId { get; set; }
    }
}

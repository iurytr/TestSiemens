using Application.PipilineBehavior;
using Domain.Entities.Dtos;
using MediatR;

namespace Application.Command
{
    public class CreateClientCommand : IRequest<Response>
    {
        public CreateClientCommand(CreateClientDto clientDto)
        {
            ClientDto = clientDto;
        }

        public CreateClientDto ClientDto { get; set; }
    }
}

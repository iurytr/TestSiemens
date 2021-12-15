

using MediatR;

namespace Application.Command
{
    public class CreateClientCommand : IRequest<Response>
    {
        public CreateClientCommand(ClientDto clientDto)
        {
            ClientDto = clientDto;
        }

        public ClientDto clientDto { get; set; }
    }
}

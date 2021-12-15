using Application.PipilineBehavior;
using MediatR;

namespace Application.Command
{
    public class UpdateClientNameCommand : IRequest<Response>
    {
        public UpdateClientNameCommand(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Name { get; set; }
        public int Id { get; set; }
    }
}

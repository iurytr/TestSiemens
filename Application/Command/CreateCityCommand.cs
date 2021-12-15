using Application.PipilineBehavior;
using Domain.Entities.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command
{
    public class CreateCityCommand : IRequest<Response>
    {
        public CreateCityCommand(CityDto cityDto)
        {
            CityDto = cityDto;
        }

        public CityDto CityDto { get; set; }
    }
}

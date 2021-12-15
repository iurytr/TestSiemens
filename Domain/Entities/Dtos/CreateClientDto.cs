using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Dtos
{
    public class CreateClientDto
    {

        public string Name { get; set; }

        public SexoType Sexo { get; set; }

        public DateTime BirthdDate { get; set; }

        public string City { get; set; }
    }
}


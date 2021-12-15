using Application.Command;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class CreateCityValidator : AbstractValidator<CreateCityCommand>
    {
        public CreateCityValidator()
        {
        
        }
    }
}

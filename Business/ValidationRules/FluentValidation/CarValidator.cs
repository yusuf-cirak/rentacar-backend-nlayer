using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {

            RuleFor(c => c.CarName).NotEmpty();

            RuleFor(c => c.CarBrandName).NotEmpty();

            RuleFor(c => c.CarColorName).NotEmpty();

            RuleFor(c => c.CarModelYear).NotEmpty();

            RuleFor(c => c.CarDailyPrice).GreaterThan(0).NotEmpty();

            RuleFor(c => c.CarDescription).NotEmpty();

        }
    }
}

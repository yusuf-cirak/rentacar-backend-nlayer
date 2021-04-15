using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalsValidator:AbstractValidator<Rentals>
    {
        public RentalsValidator()
        {

            RuleFor(r => r.CustomerId).NotEmpty();

            RuleFor(r => r.CarId).NotEmpty();

            RuleFor(r => r.RentDate).LessThan(r => r.ReturnDate).NotEmpty();

            RuleFor(r => r.ReturnDate).GreaterThan(r => r.RentDate).NotEmpty();
        }
    }
}

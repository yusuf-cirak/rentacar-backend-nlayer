using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator:AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(b => b.BrandName).MinimumLength(2);
            // RuleFor(b => b.BrandName).Must(StartWithA).WithMessage("Marka ismi A ile başlamalı"); // Örnek olarak yazılabilecek yeni bir kural.
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}

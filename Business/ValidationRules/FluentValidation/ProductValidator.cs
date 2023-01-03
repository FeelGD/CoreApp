using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            //RuleFor(p => p.Name).NotEmpty();
            //RuleFor(p => p.Name).Length(2, 30);
            //RuleFor(p => p.UnitPrice).NotEmpty();
            //RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(1);
            //RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.Id == 1);
            //RuleFor(p => p.Name).Must(StartWithWithA);
        }

        private bool StartWithWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}

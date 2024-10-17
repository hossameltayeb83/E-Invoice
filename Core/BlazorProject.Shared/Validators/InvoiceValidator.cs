using BlazorProject.Shared.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Shared.Validators
{
    public class InvoiceValidator : AbstractValidator<InvoiceDto>
    {
        public InvoiceValidator()
        {
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 200 characters.");
            RuleFor(P => P.CustomerId)
                .NotEmpty().WithMessage("Customer is required.");
            RuleFor(p => p.InvoiceLines)
                .NotEmpty().WithMessage("Invoice must contain atleast one item.");
            RuleForEach(e => e.InvoiceLines)
                .ChildRules(invoiceLine =>
                {
                    invoiceLine.RuleFor(e => e.Amount)
                                    .GreaterThan(0).WithMessage("Item {PropertyName} must be a postive value.");
                    invoiceLine.RuleFor(e => e.Quantity)
                                    .GreaterThan(0).WithMessage("Item {PropertyName} must be a postive value.")
                                    .Must(e=>e%1==0).WithMessage("Item {PropertyName} must be a whole postive value.");
                    invoiceLine.RuleFor(e => e.ItemName)
                                    .NotEmpty().WithMessage("Item must have a name.");
                    invoiceLine.RuleForEach(e => e.InvoiceLineTaxes)
                        .ChildRules(invoiceLineTax =>
                            {
                                invoiceLineTax.RuleFor(e => e.Amount)
                                                .GreaterThan(0).WithMessage("Tax {PropertyName} must be a postive value.");
                                invoiceLineTax.RuleFor(e => e.TaxRate)
                                                .GreaterThan(0).WithMessage("Tax rate must be a postive value.");
                                invoiceLineTax.RuleFor(e => e.TaxName)
                                                .NotEmpty().WithMessage("Tax must have a name.");
                            });
                });
        }
    }
}

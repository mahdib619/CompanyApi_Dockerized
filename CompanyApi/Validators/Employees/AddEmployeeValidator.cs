using CompanyApi.Models.Contracts;
using FluentValidation;

namespace CompanyApi.Validators;

public class AddEmployeeValidator : Validator<AddEmployeeRequest>
{
	public AddEmployeeValidator()
	{
		RuleFor(e => e.Name)
			.NotEmpty().WithMessage("is required!")
			.MaximumLength(50).WithMessage("length should be 50 or less!");

		RuleFor(e => e.Email)
			.NotEmpty().WithMessage("is required!")
			.MaximumLength(50).WithMessage("length should be 50 or less!");

		RuleFor(e => e.Title)
			.NotEmpty().WithMessage("is required!")
			.MaximumLength(50).WithMessage("length should be 50 or less!");

		RuleFor(e => e.Phone)
			.NotEmpty().WithMessage("is required!")
			.MaximumLength(15).WithMessage("length should be 15 or less!");

		RuleFor(e => e.CompanyId).GreaterThan(0).WithMessage("is invalid!");
	}
}

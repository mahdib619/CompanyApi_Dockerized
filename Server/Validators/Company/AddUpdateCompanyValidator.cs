using FluentValidation;
using CompanyApp.Shared.Models.Request;

namespace CompanyApp.Server.Validators.Company;

public class AddUpdateCompanyValidator : Validator<AddUpdateCompanyRequest>
{
	public AddUpdateCompanyValidator()
	{
		RuleFor(auc => auc.Name)
			.NotEmpty().WithMessage("is required!")
			.MaximumLength(50).WithMessage("length should be 50 or less!");

		RuleFor(auc => auc.City)
			.NotEmpty().WithMessage("is required!")
			.MaximumLength(50).WithMessage("length should be 50 or less!");

		RuleFor(auc => auc.State)
			.NotEmpty().WithMessage("is required!")
			.MaximumLength(50).WithMessage("length should be 50 or less!");

		RuleFor(auc => auc.PostalCode)
			.NotEmpty().WithMessage("is required!")
			.MaximumLength(15).WithMessage("length should be 15 or less!");
	}
}

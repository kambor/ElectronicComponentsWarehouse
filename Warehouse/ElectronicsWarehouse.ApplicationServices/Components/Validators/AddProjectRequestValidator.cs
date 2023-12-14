using ElectronicsWarehouse.ApplicationServices.API.Domain.Requests.Projects;
using FluentValidation;

namespace ElectronicsWarehouse.ApplicationServices.Components.Validators;

public class AddProjectRequestValidator : AbstractValidator<AddProjectRequest>
{
    public AddProjectRequestValidator()
    {
        RuleFor(x => x.TotalCost).GreaterThanOrEqualTo(0).WithMessage("WRONG_VALUE");
        RuleFor(x => x.Name).Length(1, 100);
    }
}

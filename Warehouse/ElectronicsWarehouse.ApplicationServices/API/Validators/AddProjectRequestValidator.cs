using ElectronicsWarehouse.ApplicationServices.API.Domain.Requests.Projects;
using FluentValidation;

namespace ElectronicsWarehouse.ApplicationServices.API.Validators;

public class AddProjectRequestValidator : AbstractValidator<AddProjectRequest>
{
    public AddProjectRequestValidator()
    {
        this.RuleFor(x => x.TotalCost).GreaterThanOrEqualTo(0).WithMessage("WRONG_VALUE");
        this.RuleFor(x => x.Name).Length(1, 100);
    }
}

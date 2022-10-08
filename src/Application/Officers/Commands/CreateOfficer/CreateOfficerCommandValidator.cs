using FluentValidation;

namespace SuddanApplication.Application.Officers.Commands.CreateOfficer;
public class CreateOfficerCommandValidator : AbstractValidator<CreateOfficerCommand>
{
    public CreateOfficerCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(200)
            .NotEmpty();
    }
}

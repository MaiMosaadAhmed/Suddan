using FluentValidation;

namespace SuddanApplication.Application.Officers.Commands.UpdateOfficer;
public class UpdateOfficerCommandValidator : AbstractValidator<UpdateOfficerCommand>
{
    public UpdateOfficerCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(200)
            .NotEmpty();
    }
}

using FluentValidation;

namespace SuddanApplication.Application.Driver.Commands;
public class UpdateDriverCommandValidator : AbstractValidator<UpdateDriverCommand>
{
    public UpdateDriverCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(200)
            .NotEmpty();
    }
}

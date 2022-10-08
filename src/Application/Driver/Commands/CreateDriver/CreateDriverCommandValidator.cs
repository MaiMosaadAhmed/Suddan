using FluentValidation;

namespace SuddanApplication.Application.Driver.Commands;
public class CreateDriverCommandValidator : AbstractValidator<CreateDriverCommand>
{
    public CreateDriverCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(200)
            .NotEmpty();
    }
}

using FluentValidation;
using SuddanApplication.Application.CarOwner.Commands;

namespace SuddanApplication.Application.CarOwner.Commands.CreateTodoItem;
public class CreateCarOwnerCommandValidator : AbstractValidator<CreateCarOwnerCommand>
{
    public CreateCarOwnerCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(200)
            .NotEmpty();
    }
}

using FluentValidation;

namespace SuddanApplication.Application.CarOwner.Commands.UpdateCarOwner;
public class UpdateCarOwnerCommandValidator : AbstractValidator<UpdateCarOwnerCommand>
{
    public UpdateCarOwnerCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(200)
            .NotEmpty();
    }
}

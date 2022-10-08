using FluentValidation;

namespace SuddanApplication.Application.Car.Commands.UpdateCar;
public class UpdateCarCommandValidator : AbstractValidator<UpdateCarCommand>
{
    public UpdateCarCommandValidator()
    {
        RuleFor(v => v.CarPlateNumber)
            .MaximumLength(200)
            .NotEmpty();
    }
}

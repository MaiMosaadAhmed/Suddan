using FluentValidation;

namespace SuddanApplication.Application.Car.Commands.CreateCar;
public class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
{
    public CreateCarCommandValidator()
    {
        RuleFor(v => v.CarPlateNumber)
            .MaximumLength(200)
            .NotEmpty();
    }
}

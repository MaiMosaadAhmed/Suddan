using FluentValidation;

namespace SuddanApplication.Application.Nodes.Commands.CreateNodes;
public class CreateNodesCommandValidator : AbstractValidator<CreateNodesCommand>
{
    public CreateNodesCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(200)
            .NotEmpty();
    }
}

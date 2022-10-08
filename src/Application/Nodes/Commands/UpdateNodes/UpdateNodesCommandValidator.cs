using FluentValidation;

namespace SuddanApplication.Application.Nodes.Commands.UpdateNodes;
public class UpdateNodesCommandValidator : AbstractValidator<UpdateNodesCommand>
{
    public UpdateNodesCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(200)
            .NotEmpty();
    }
}

using System.Globalization;
using FluentValidation;
using TaskManager.Application.Commands;

namespace TaskManager.Application.Validators;

public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
{
    public CreateTaskCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Название задачи обязательно")
            .MaximumLength(70).WithMessage("Название не должно превышать 70 символов");

        RuleFor(x => x.Description)
            .MaximumLength(200).WithMessage("Описание не должно превышать 200 символов");
    }
}
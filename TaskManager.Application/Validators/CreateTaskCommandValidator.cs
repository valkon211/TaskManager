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
            .MaximumLength(100).WithMessage("Название не должно превышать 100 символов");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Описание не должно превышать 500 символов");

        RuleFor(x => x.DueDate)
            .GreaterThan(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)).WithMessage("Дата завершения должна быть больше текущей");
    }
}
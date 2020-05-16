using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace VocabularyBuilder.Application.Categories.Commands.AddCategoryCommand
{
    public class AddCategoryCommandValidator:AbstractValidator<AddCategoryCommand>
    {
        public AddCategoryCommandValidator()
        {
            RuleFor(e => e.Description).NotEmpty().MaximumLength(100);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace VocabularyBuilder.Application.Categories.Commands.DeleteCategoryCommand
{
    public class DeleteCategoryCommandValidator:AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandValidator()
        {
            RuleFor(e => e.Id).NotEmpty();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace VocabularyBuilder.Application.Categories.Commands.UpdateCategoryCommand
{
    public class UpdateCategoryCommandValidator:AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(e => e.Description).NotEmpty().MaximumLength(100);
        }
    }
}

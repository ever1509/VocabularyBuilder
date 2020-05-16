using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace VocabularyBuilder.Application.Categories.Commands.UpdateCategoryCommand
{
    public class UpdateCategoryCommand:IRequest
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}

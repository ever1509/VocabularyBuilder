using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace VocabularyBuilder.Application.Categories.Commands.DeleteCategoryCommand
{
    public class DeleteCategoryCommand:IRequest
    {
        public int Id { get; set; }
    }
}

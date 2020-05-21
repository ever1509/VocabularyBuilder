using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.FlashCards.Commands.AddFlashCard
{
    public class AddFlashCardCommandHandler:IRequestHandler<AddFlashCardCommand,int>
    {
        private readonly IVocabularyBuilderDbContext _context;
        private ILogger<AddFlashCardCommandHandler> _logger;

        public AddFlashCardCommandHandler(IVocabularyBuilderDbContext context, ILogger<AddFlashCardCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<int> Handle(AddFlashCardCommand request, CancellationToken cancellationToken)
        {
            

            FlashCard entity = new FlashCard()
            {
                MainWord = request.MainWord,
                CategoryId = request.Category,
                Example = request.Example,
                FlashCardPicture = request.Picture,
                TypeCardId = (int)request.TypeCard,
                FlashCardDate = DateTime.Now,
                Meaning = request.Meaning,
                UserId = request.UserId

            };

            _context.FlashCards.Add(entity);

             await _context.SaveChangesAsync(cancellationToken);

             return entity.FlashCardId;
        }

    }
}

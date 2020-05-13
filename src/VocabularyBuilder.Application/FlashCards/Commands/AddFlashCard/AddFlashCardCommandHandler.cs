using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using VocabularyBuilder.Data;
using VocabularyBuilder.Domain.Entities;

namespace VocabularyBuilder.Application.FlashCards.Commands.AddFlashCard
{
    public class AddFlashCardCommandHandler:IRequestHandler<AddFlashCardCommand,int>
    {
        private readonly VocabularyBuilderContext _context;
        private ILogger<AddFlashCardCommandHandler> _logger;

        public AddFlashCardCommandHandler(VocabularyBuilderContext context, ILogger<AddFlashCardCommandHandler> logger)
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
                MeaningId = await NewMeaning(request.Meaning,cancellationToken),
                UserId = request.UserId

            };

            _context.FlashCards.Add(entity);

             await _context.SaveChangesAsync(cancellationToken);

             return entity.FlashCardId;
        }

        private async Task<int> NewMeaning(string requestMeaning, CancellationToken cancellationToken)
        {
            Meaning newMeaning= new Meaning(){Description = requestMeaning};

            _context.Meanings.Add(newMeaning);
            await _context.SaveChangesAsync(cancellationToken);

            return newMeaning.MeaningId;
        }

    }
}

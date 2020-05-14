using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VocabularyBuilder.Data;

namespace VocabularyBuilder.Application.FlashCards.Queries.GetFlashCards
{
    public class GetFlashCardsQueryHandler:IRequestHandler<GetFlashCardsQuery,FlashCardsListVm>
    {
        private readonly VocabularyBuilderContext _context;
        private readonly IMapper _mapper;

        public GetFlashCardsQueryHandler(VocabularyBuilderContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<FlashCardsListVm> Handle(GetFlashCardsQuery request, CancellationToken cancellationToken)
        {
            if (_context.FlashCards.Any())
            {
                try
                {
                    var flashcards = await _context.FlashCards
                        .Where(f => f.TypeCardId == (int)request.TypeCard)
                        .ProjectTo<FlashCardDto>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken);
                   
                    return new FlashCardsListVm()
                    {
                        FlashCards = flashcards
                    };
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
               

             
            }

            return new FlashCardsListVm();
        }
    }
}

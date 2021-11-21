using TolkienApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace TolkienApi.Services
{
    public class CharacterService
    {
        private readonly QuoteService _quoteService;
        readonly Dictionary<string, Character> Characters = new();

        public CharacterService(QuoteService quoteService)
        {
            _quoteService = quoteService;
            // foreach (Quote q in _quoteService.GetAll())
            // {
            //     Characters.Add(q.Character, new Character()
            //     {
            //         Name = q.Character,
            //         LotrUrl = $"- http://lotr.wikia.com/?curid={q.Lotr_page_id}",
            //     });  
            // }
        }

        public Dictionary<string, Character> GetCharacters() => Characters;

        public Character GetCharacterDetails(string author)
        {
            IEnumerable<Quote> authorQuotes = _quoteService.GetByAuthor(author);
            Character authorDetails = new Character()
            {
                Name = author,
                // LotrUrl = $"- http://lotr.wikia.com/?curid={q.Lotr_page_id}",
                Quotes = authorQuotes
            };
            return authorDetails;
        }

    }
}
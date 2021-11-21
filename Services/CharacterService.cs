using TolkienApi.Helpers;
using TolkienApi.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace TolkienApi.Services
{
    public class CharacterService
    {
        private readonly DataContext _context;
        private readonly QuoteService _quoteService;

        public CharacterService(DataContext context, QuoteService quoteService)
        {
            _context = context;
            _quoteService = quoteService;
        }

        public IEnumerable<Character> Get(int count)
        {
            return (count > 0 && count <= _context.Characters.Count())
                ? _context.Characters.Take(count)
                : _context.Characters;
        }

        public Character GetById(int id)
        {
            Character character = _context.Characters.FirstOrDefault(p => p.Id == id);
            if (character != null)
            {
                IEnumerable<Quote> quotes = _quoteService.GetByAuthor(character.Name);
                if (quotes.Any()) character.Quotes = quotes;
                character.Lotr_url = $"http://lotr.wikia.com/?curid={character.Lotr_page_id}";
            }
            return character;
        }

        public Character GetRandom() => _context.Characters.ToList()[new Random().Next(0, _context.Characters.Count())];

        public void Add(Character character)
        {
            _context.Characters.Add(character);
            _context.SaveChanges();
        }

        public void Delete(Character character)
        {
            _context.Characters.Remove(character);
            _context.SaveChanges();
        }

        public void Replace(Character oldCharacter, Character newCharacter)
        {
            _context.Entry(oldCharacter).CurrentValues.SetValues(newCharacter);
            _context.SaveChanges();
        }

        public void Update(Character character)
        {
            _context.Characters.Update(character);
            _context.SaveChanges();
        }

        public int GetCount() => _context.Characters.Count();
    }
}
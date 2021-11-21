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

        public IEnumerable<Character> GetAll() => _context.Characters;

        public Character GetById(int id) {
            var character = _context.Characters.FirstOrDefault(p => p.Id == id);
            if (character != null)
            {
                character.Quotes = _quoteService.GetByAuthor(character.Name);
                character.LotrUrl = $"- http://lotr.wikia.com/?curid={character.Lotr_page_id}";
            }
            return character;
        }

        public Character GetRandom() => _context.Characters.ToList()[new Random().Next(0, _context.Characters.Count())];

        public void Add(Character quote)
        {
            _context.Characters.Add(quote);
            _context.SaveChanges();
        }

        public void Delete(Character quote)
        {
            _context.Characters.Remove(quote);
            _context.SaveChanges();
        }

        public void Replace(Character oldCharacter, Character newCharacter)
        { 
            _context.Entry(oldCharacter).CurrentValues.SetValues(newCharacter);
            _context.SaveChanges();
        }

        public void Update(Character quote)
        {
            _context.Characters.Update(quote);
            _context.SaveChanges();
        }

    }
}
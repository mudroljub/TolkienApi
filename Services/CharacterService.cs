using AutoMapper;
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
        private readonly IMapper _mapper;

        public CharacterService(DataContext context, QuoteService quoteService, IMapper mapper)
        {
            _context = context;
            _quoteService = quoteService;
            _mapper = mapper;
        }

        public IEnumerable<Character> Get(int count)
        {
            return (count > 0 && count <= _context.Characters.Count())
                ? _context.Characters.Take(count)
                : _context.Characters;
        }

        public IEnumerable<Character> GetByLocation(string location) => _context.Characters.Where(p => p.Location == location);

        public Character GetById(int id)
        {
            Character character = _context.Characters.FirstOrDefault(p => p.Id == id);
            if (character != null)
            {
                IEnumerable<Quote> quotes = _quoteService.GetByCharacter(character.Name);
                if (quotes.Any()) character.Quotes = quotes;
                character.Lotr_url = $"http://lotr.wikia.com/?curid={character.Lotr_page_id}";
            }
            return character;
        }

        public Character GetByName(string name)
        {
            Character character = _context.Characters.FirstOrDefault(p => p.Name.ToLower() == name.ToLower());
            if (character != null)
            {
                IEnumerable<Quote> quotes = _quoteService.GetByCharacter(character.Name);
                if (quotes.Any()) character.Quotes = quotes;
                character.Lotr_url = $"http://lotr.wikia.com/?curid={character.Lotr_page_id}";
            }
            return character;
        }

        public Character GetRandom() => _context.Characters.ToList()[new Random().Next(0, _context.Characters.Count())];

        public void Add(CharacterNew data)
        {
            Character character = _mapper.Map<Character>(data);
            _context.Characters.Add(character);
            _context.SaveChanges();
        }

        public void Delete(Character character)
        {
            _context.Characters.Remove(character);
            _context.SaveChanges();
        }

        public int GetCount() => _context.Characters.Count();
    }
}
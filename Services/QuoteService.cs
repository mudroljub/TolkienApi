using TolkienApi.Helpers;
using TolkienApi.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace TolkienApi.Services
{
    public class QuoteService
    {
        private readonly DataContext _context;

        public QuoteService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Quote> GetAll() => _context.Quotes;

        public Quote GetById(int id) => _context.Quotes.FirstOrDefault(p => p.Id == id);

        public Quote GetRandom() => _context.Quotes.ToList()[new Random().Next(0, _context.Quotes.Count())];

        public IEnumerable<Quote> GetByAuthor(string author) => _context.Quotes.Where(p => p.Character == author);

        public void Add(Quote quote)
        {
            _context.Quotes.Add(quote);
            _context.SaveChanges();
        }

        public void Delete(Quote quote)
        {
            _context.Quotes.Remove(quote);
            _context.SaveChanges();
        }

        public void Replace(Quote oldQuote, Quote newQuote)
        { 
            _context.Entry(oldQuote).CurrentValues.SetValues(newQuote);
            _context.SaveChanges();
        }

        public void Update(Quote quote)
        {
            _context.Quotes.Update(quote);
            _context.SaveChanges();
        }
    }
}
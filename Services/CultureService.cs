using TolkienApi.Helpers;
using TolkienApi.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace TolkienApi.Services
{
    public class CultureService
    {
        private readonly DataContext _context;

        public CultureService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Culture> GetAll() => _context.Cultures;

        public Culture GetById(int id) => _context.Cultures.FirstOrDefault(p => p.Id == id);

        public Culture GetRandom() => _context.Cultures.ToList()[new Random().Next(0, _context.Cultures.Count())];

        private static bool Includes(string line, string word)
        {
            if (string.IsNullOrEmpty(line))
                return false;

            List<string> parts = line.Split(',').Select(p => p.Trim()).ToList();
            return parts.Any(s => string.Equals(s, word, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Culture> GetByCharacter(string character) => _context.Cultures.Where(p => Includes(p.Characters, character));

        public IEnumerable<Culture> GetByLocation(string location) => _context.Cultures.Where(p => Includes(p.Locations, location));

        public void Add(Culture culture)
        {
            _context.Cultures.Add(culture);
            _context.SaveChanges();
        }

        public void Delete(Culture culture)
        {
            _context.Cultures.Remove(culture);
            _context.SaveChanges();
        }

        public void Replace(Culture oldCulture, Culture newCulture)
        {
            _context.Entry(oldCulture).CurrentValues.SetValues(newCulture);
            _context.SaveChanges();
        }

        public void Update(Culture culture)
        {
            _context.Cultures.Update(culture);
            _context.SaveChanges();
        }

        public int GetCount() => _context.Cultures.Count();
    }
}
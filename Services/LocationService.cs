using TolkienApi.Helpers;
using TolkienApi.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace TolkienApi.Services
{
    public class LocationService
    {
        private readonly DataContext _context;

        public LocationService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Location> GetAll() => _context.Locations;

        public IEnumerable<Location> Get(int count)
        {
            return (count > 0 && count <= _context.Locations.Count())
                ? _context.Locations.Take(count)
                : _context.Locations;
        }

        public Location GetById(int id) => _context.Locations.FirstOrDefault(p => p.Id == id);

        public Location GetRandom() => _context.Locations.ToList()[new Random().Next(0, _context.Locations.Count())];

        private static bool Includes(string line, string word)
        {
            if (string.IsNullOrEmpty(line))
                return false;

            List<string> parts = line.Split(',').Select(p => p.Trim()).ToList();
            return parts.Any(s => string.Equals(s, word, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Location> GetByCulture(string culture) => _context.Locations.Where(p => Includes(p.Cultures, culture));

        public void Add(Location culture)
        {
            _context.Locations.Add(culture);
            _context.SaveChanges();
        }

        public void Delete(Location culture)
        {
            _context.Locations.Remove(culture);
            _context.SaveChanges();
        }

        public void Replace(Location oldLocation, Location newLocation)
        {
            _context.Entry(oldLocation).CurrentValues.SetValues(newLocation);
            _context.SaveChanges();
        }

        public void Update(Location culture)
        {
            _context.Locations.Update(culture);
            _context.SaveChanges();
        }

        public int GetCount() => _context.Locations.Count();
    }
}
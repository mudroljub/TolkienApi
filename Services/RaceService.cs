using TolkienApi.Helpers;
using TolkienApi.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace TolkienApi.Services
{
    public class RaceService
    {
        private readonly DataContext _context;

        public RaceService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Race> GetAll() => _context.Races;

        public Race GetById(int id) => _context.Races.FirstOrDefault(p => p.Id == id);

        public Race GetRandom() => _context.Races.ToList()[new Random().Next(0, _context.Races.Count())];

        private static bool Includes(string line, string word)
        {
            if (string.IsNullOrEmpty(line))
                return false;

            List<string> parts = line.Split(',').Select(p => p.Trim()).ToList();
            return parts.Any(s => string.Equals(s, word, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Race> GetByLocation(string location) => _context.Races.Where(p => Includes(p.Locations, location));

        public void Add(Race race)
        {
            _context.Races.Add(race);
            _context.SaveChanges();
        }

        public void Delete(Race race)
        {
            _context.Races.Remove(race);
            _context.SaveChanges();
        }

        public void Replace(Race oldRace, Race newRace)
        {
            _context.Entry(oldRace).CurrentValues.SetValues(newRace);
            _context.SaveChanges();
        }

        public void Update(Race race)
        {
            _context.Races.Update(race);
            _context.SaveChanges();
        }

        public int GetCount() => _context.Races.Count();
    }
}
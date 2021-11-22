using TolkienApi.Helpers;
using TolkienApi.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace TolkienApi.Services
{
    public class BattleService
    {
        private readonly DataContext _context;

        public BattleService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Battle> GetAll() => _context.Battles;

        public Battle GetById(int id) => _context.Battles.FirstOrDefault(p => p.Id == id);

        public Battle GetRandom() => _context.Battles.ToList()[new Random().Next(0, _context.Battles.Count())];

        public IEnumerable<Battle> GetByLocation(string location) => _context.Battles.Where(p => p.Location == location);

        public void Add(Battle battle)
        {
            _context.Battles.Add(battle);
            _context.SaveChanges();
        }

        public void Delete(Battle battle)
        {
            _context.Battles.Remove(battle);
            _context.SaveChanges();
        }

        public void Replace(Battle oldBattle, Battle newBattle)
        { 
            _context.Entry(oldBattle).CurrentValues.SetValues(newBattle);
            _context.SaveChanges();
        }

        public void Update(Battle battle)
        {
            _context.Battles.Update(battle);
            _context.SaveChanges();
        }

        public int GetCount() => _context.Battles.Count();
    }
}
using TolkienApi.Helpers;
using TolkienApi.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace TolkienApi.Services
{
    public class ArtefactService
    {
        private readonly DataContext _context;

        public ArtefactService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Artefact> GetAll() => _context.Artefacts;

        public Artefact GetById(int id) => _context.Artefacts.FirstOrDefault(p => p.Id == id);

        public Artefact GetRandom() => _context.Artefacts.ToList()[new Random().Next(0, _context.Artefacts.Count())];

        public IEnumerable<Artefact> GetByCharacter(string character) => _context.Artefacts.Where(p => p.Character == character);

        public void Add(Artefact artefact)
        {
            _context.Artefacts.Add(artefact);
            _context.SaveChanges();
        }

        public void Delete(Artefact artefact)
        {
            _context.Artefacts.Remove(artefact);
            _context.SaveChanges();
        }

        public void Replace(Artefact oldArtefact, Artefact newArtefact)
        { 
            _context.Entry(oldArtefact).CurrentValues.SetValues(newArtefact);
            _context.SaveChanges();
        }

        public void Update(Artefact artefact)
        {
            _context.Artefacts.Update(artefact);
            _context.SaveChanges();
        }

        public int GetCount() => _context.Artefacts.Count();
    }
}
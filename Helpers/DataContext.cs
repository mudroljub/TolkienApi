using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using TolkienApi.Models;

namespace TolkienApi.Helpers
{
    public class DataContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Artefact> Artefacts { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<Culture> Cultures { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Race> Races { get; set; }

        private readonly JsonSerializerOptions JsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public DataContext()
        {
            Init<Quote>(Quotes, "Data/quotes.json")
            Init<Character>(Characters, "Data/characters.json")
            Init<Artefact>(Artefacts, "Data/artefacts.json")
            Init<Battle>(Battles, "Data/battles.json")
            Init<Culture>(Cultures, "Data/cultures.json")
            Init<Location>(Locations, "Data/locations.json")
            Init<Race>(Races, "Data/races.json")
        }

        private void Init<T>(DbSet<T> dbSet, string filePath) {
            if(dbSet.Any()) return;

            string fileContent = File.ReadAllText(filePath);
            List<T> data = JsonSerializer.Deserialize<List<T>>(fileContent, JsonOptions);

            dbSet.AddRange(data);
            SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("TestDb");
        }

    }
}
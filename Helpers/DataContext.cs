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

        private readonly JsonSerializerOptions JsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public DataContext()
        {
            InitQuotes();
            InitCharacters();
            InitArtefacts();
        }

        private void InitQuotes()
        {
            if (Quotes.Any()) return;

            string fileContent = File.ReadAllText("Data/quotes.json");
            List<Quote> quotes = JsonSerializer.Deserialize<List<Quote>>(fileContent, JsonOptions);

            Quotes.AddRange(quotes);
            SaveChanges();
        }

        private void InitCharacters()
        {
            if (Characters.Any()) return;

            string fileContent = File.ReadAllText("Data/characters.json");
            List<Character> characters = JsonSerializer.Deserialize<List<Character>>(fileContent, JsonOptions);

            Characters.AddRange(characters);
            SaveChanges();
        }

        private void InitArtefacts()
        {
            if (Artefacts.Any()) return;

            string fileContent = File.ReadAllText("Data/artefacts.json");
            List<Artefact> artefact = JsonSerializer.Deserialize<List<Artefact>>(fileContent, JsonOptions);

            Artefacts.AddRange(artefact);
            SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("TestDb");
        }

    }
}
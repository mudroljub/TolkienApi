using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TolkienApi.Models
{
    public class Character : CharacterNew
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Url]
        public string Lotr_url { get; set; }

        public IEnumerable<Quote> Quotes { get; set; }

        public string Birth { get; set; }
        public string Culture { get; set; }
        public string Death { get; set; }
        public string Eyes { get; set; }
        public string Hair_color { get; set; }
        public string Height { get; set; }
        public string Location { get; set; }
        public string Other_names { get; set; }
        public string Rule { get; set; }
        public string Spouse { get; set; }
        public string Titles { get; set; }
        public string Weapon { get; set; }
    }
}

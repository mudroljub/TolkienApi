using System.ComponentModel.DataAnnotations;

namespace TolkienApi.Models
{
    public class Character
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Race { get; set; }

        [Required]
        public string Lotr_page_id { get; set; }

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

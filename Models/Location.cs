using System.ComponentModel.DataAnnotations;

namespace TolkienApi.Models
{
    public class Location
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string Lotr_page_id { get; set; }

        public string Capital { get; set; }
        public string Cultures { get; set; }
        public string Description { get; set; }
        public string Events { get; set; }
        public string Founded_or_built { get; set; }
        public string Governance { get; set; }
        public string Lifespan { get; set; }
        public string Major_towns { get; set; }
        public string Other_names { get; set; }
        public string Position { get; set; }
        public string Regions { get; set; }
        public string Type { get; set; }
    }
}

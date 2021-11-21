using System.ComponentModel.DataAnnotations;

namespace TolkienApi.Models
{
    public class Race
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Locations { get; set; }
        [Required]
        public string Distinctions { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string Lotr_page_id { get; set; }
        public string Characters { get; set; }
        public string Hair_color { get; set; }
        public string Height { get; set; }
        public string Languages { get; set; }
        public string Lifespan { get; set; }
        public string Origins { get; set; }
        public string Other_names { get; set; }
        public string Skin_color { get; set; }
    }
}

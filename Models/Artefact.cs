using System.ComponentModel.DataAnnotations;

namespace TolkienApi.Models
{
    public class Artefact
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string Lotr_page_id { get; set; }
        [Required]
        public string Character { get; set; }

        public string Appearance { get; set; }
        public string Location { get; set; }
        public string Other_names { get; set; }
        public string Usage { get; set; }
    }
}

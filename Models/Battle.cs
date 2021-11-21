using System.ComponentModel.DataAnnotations;

namespace TolkienApi.Models
{
    public class Battle
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string Lotr_page_id { get; set; }
        [Required]
        public string Location { get; set; }

        public string Conflict { get; set; }
        public string Date { get; set; }
        public string Outcome { get; set; }
    }
}

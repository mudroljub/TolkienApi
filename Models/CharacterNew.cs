using System.ComponentModel.DataAnnotations;

namespace TolkienApi.Models
{
    public class CharacterNew
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
    }
}

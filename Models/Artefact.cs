using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TolkienApi.Models
{
    public class Artefact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string Lotr_page_id { get; set; }
        [Required]
        public string Character { get; set; }
        [Url]
        public string Lotr_url { 
            get { return $"http://lotr.wikia.com/?curid={Lotr_page_id}"; }   
        }

        public string Appearance { get; set; }
        public string Location { get; set; }
        public string Other_names { get; set; }
        public string Usage { get; set; }
    }
}

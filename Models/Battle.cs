using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TolkienApi.Models
{
    public class Battle
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
        public string Location { get; set; }
        [Url]
        public string Lotr_url { 
            get { return $"http://lotr.wikia.com/?curid={Lotr_page_id}"; }   
        }

        public string Conflict { get; set; }
        public string Date { get; set; }
        public string Outcome { get; set; }
    }
}

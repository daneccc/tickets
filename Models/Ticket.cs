using System.ComponentModel.DataAnnotations;

namespace Tickets.API.Models {
    public class Ticket {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Description { get; set; }
        public string AuthorName { get; set; }
        public string Date { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace Webbapi.Models
{
    public class Restaurang
    {
        [Key]
        public int Id { get; set; }
        public string Namn {get; set;} = "Jonas Kött";

        public string Adress {get; set;} = "Nybergsgatan 52";

        public Maträtter typ {get; set;} = Maträtter.Kött;

      
    }
}
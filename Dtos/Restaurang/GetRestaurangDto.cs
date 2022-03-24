using Webbapi.Models;

namespace Webbapi.Dtos.Restaurang
{
    public class GetRestaurangDto
    {
        public string Namn {get; set;} = "Jonas Kött";

        public string Adress {get; set;} = "Nybergsgatan 52";

        public Maträtter typ {get; set;} = Maträtter.Kött;
    }
}
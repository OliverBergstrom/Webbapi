namespace Webbapi.Models
{
    public class Restaurang
    {
        public string Namn {get; set;} = "Jonas Kött";

        public string Adress {get; set;} = "Nybergsgatan 52";

        public Maträtter typ {get; set;} = Maträtter.Kött;

        internal static void Add(Restaurang newRestaurang)
        {
            throw new NotImplementedException();
        }
    }
}
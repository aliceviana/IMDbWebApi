using System.Collections.Generic;
using System.Linq;

namespace IMDb.Business.Models
{
    public class Filme : Entity
    {
        public Filme()
        {
            Atores = new List<Ator>();
            Votos = new List<Voto>();
        }

        public string Nome { get; set; }

        public string Diretor { get; set; }

        public string Genero { get; set; }

        public decimal Nota => Votos.Count > 0 ? Votos.Average(x => x.Nota) : 0; 

        public List<Ator> Atores { get; set; }

        public List<Voto> Votos { get; set; }
    }
}

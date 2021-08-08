using System;

namespace IMDb.Business.Models
{
    public class Voto : Entity
    {
        public Guid FilmeId { get; set; }

        public Filme Filme { get; set; }

        public Guid UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

        public decimal Nota { get; set; }
    }
}

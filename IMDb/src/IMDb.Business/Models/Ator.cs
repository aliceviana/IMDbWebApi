using IMDb.Business.Models.Validations;
using System;

namespace IMDb.Business.Models
{
    public class Ator : Entity
    {
        public Guid FilmeId { get; set; }

        public Filme Filme { get; set; }

        public string Nome { get; set; }
    }
}

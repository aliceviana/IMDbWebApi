using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IMDb.Api.DTO
{
    public  class FilmeResponseDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Diretor { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Genero { get; set; }

        public List<AtorDTO> Atores { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Nota { get; set; }
    }
}

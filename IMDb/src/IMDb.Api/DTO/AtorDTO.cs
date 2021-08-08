using System.ComponentModel.DataAnnotations;

namespace IMDb.Api.DTO
{
    public class AtorDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }
    }
}

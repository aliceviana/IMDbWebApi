using System.ComponentModel.DataAnnotations;

namespace IMDb.Api.DTO
{
    public class VotoDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Nota { get; set; }
    }
}

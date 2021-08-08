using IMDb.Business.Models.Validations;

namespace IMDb.Business.Models
{
    public class Usuario : Entity
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string Role { get; set; }
    }
}

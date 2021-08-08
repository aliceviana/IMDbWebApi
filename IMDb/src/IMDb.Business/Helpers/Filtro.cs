namespace IMDb.Business.Helpers
{
    public class Filtro
    {
        public Filtro(int numeroPagina, int tamanhoPagina)
        {
            this.NumeroPagina = numeroPagina < 1 ? 1 : numeroPagina;
            this.TamanhoPagina = tamanhoPagina > 10 ? 10 : tamanhoPagina;
        }

        public Filtro()
        {
            this.NumeroPagina = 1;
            this.TamanhoPagina = 10;
        }

        public int NumeroPagina { get; set; }
        public int TamanhoPagina { get; set; }
    }
}

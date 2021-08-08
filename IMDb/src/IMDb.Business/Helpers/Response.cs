using System.Collections.Generic;

namespace IMDb.Business.Helpers
{
    public class Response<T>
    {
        public Response(List<T> dados, int total)
        {
            Dados = dados;
            Total = total;
        }

        public List<T> Dados { get; set; }
        public int Total { get; set; }
    }
}

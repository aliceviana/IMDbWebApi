using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDb.Api.DTO
{
    public class ResponseDTO<T>
    {
        public ResponseDTO(List<T> dados, int total)
        {
            Dados = dados;
            Total = total;
        }

        public List<T> Dados { get; set; }
        public int Total { get; set; }
    }
}

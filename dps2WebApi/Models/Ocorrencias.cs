using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dps2WebApi.Models
{
    public class Ocorrencias
    {

        public int id { get; set; }
        public long cpf_funcionario { get; set; }
        public long cpf_cliente { get; set; }
        public DateTime datahora { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public int senha_utilizada { get; set; }
        public string historico { get; set; }

    }
}
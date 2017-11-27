using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dps2WebApi.Models
{
    public class Clientes
    {

        public int cpf { get; set; }
        public string nome { get; set; }
        public DateTime nascimento { get; set; }
        public string estado_civil { get; set; }
        public int cep { get; set; }
        public string endereco { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public string  telefone_residencial { get; set; }
        public string telefone_comercial { get; set; }
        public string telefone_celular { get; set; }
        public int senha { get; set; }
        public DateTime acesso { get; set; }
        public string email { get; set; }
        public int ativo { get; set; }
        public int senha_liberacao { get; set; }
        public int senha_panico { get; set; }

    }
}
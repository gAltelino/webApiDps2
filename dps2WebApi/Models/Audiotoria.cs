using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dps2WebApi.Models
{
    public class Audiotoria
    {


        public int id { get; set; }
        public int cpf_auditoria { get; set; }
        public string descricao { get; set; }
        public DateTime data { get; set; }
        public string hora { get; set; }

    }
}
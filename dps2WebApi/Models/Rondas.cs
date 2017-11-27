using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dps2WebApi.Models
{
    public class Rondas
    {

        public int id { get; set; }
        public long cpf_ronda { get; set; }
        public DateTime datahora { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using dps2WebApi.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace dps2WebApi.Controllers
{
    public class RondasController :ApiController
    {

        private readonly IRondas rondas;

        public RondasController()
        {
            rondas = new RondaRepo();
        }

        [HttpGet]
        public IEnumerable<Rondas> List()
        {
            return rondas.All;
        }

        [HttpPost()]
        public void Post([FromBody] float longi, float lati, int cpf)
        {
            rondas.inserir(longi, lati, cpf);
        }
    }
}
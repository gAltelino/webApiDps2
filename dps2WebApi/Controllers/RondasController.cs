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
    public class RondasController : ApiController
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

        // POST: api/Rondas
        [HttpPost]
        public HttpResponseMessage Post(float longi, float lati, long cpf)
        {

           rondas.InserirRondas(longi, lati, cpf);
            return Request.CreateResponse(HttpStatusCode.Created);

        }
    }
}
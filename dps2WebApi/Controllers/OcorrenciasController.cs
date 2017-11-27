using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using dps2WebApi.Models;

namespace dps2WebApi.Controllers
{
    public class OcorrenciasController : ApiController
    {
        private readonly IOcorrencia ocorrencia;

        public OcorrenciasController()
        {
            ocorrencia = new OcorrenciaRepo();
        }

        [HttpPost]
        public HttpResponseMessage acionamentoEmergencia(float longi, float lati, long cpf, string historico)
        {

            ocorrencia.acionamentoEmergencia(cpf, lati, longi, historico);
            return Request.CreateResponse(HttpStatusCode.Created);

        }

        public HttpResponseMessage acionamentoPanico(float longi, float lati, long cpf, int senha)
        {

            ocorrencia.acionamentoPanico(cpf, lati, longi, senha);
            return Request.CreateResponse(HttpStatusCode.Created);

        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dps2WebApi.Models
{
    public class OcorrenciaRepo : IOcorrencia
    {

        public void acionamentoPanico(long cpf, float lati, float longi, int senha)
        {
            ocorrenciaOperacoes.InserirPanico(cpf, lati, longi, senha);
        }

        public void acionamentoEmergencia(long cpf, float lati, float longi, string historico)
        {
            ocorrenciaOperacoes.InserirEmergencia(cpf, lati, longi, historico);
        }
       

    }
}
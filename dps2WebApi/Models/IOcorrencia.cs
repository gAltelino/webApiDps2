using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dps2WebApi.Models
{
    public interface IOcorrencia
    {

        void acionamentoEmergencia(long cpf, float lati, float longi, string historico);
        void acionamentoPanico(long cpf, float lati, float longi, int senha);
        //void acionamentoEmergenciaImagem();

    }
}
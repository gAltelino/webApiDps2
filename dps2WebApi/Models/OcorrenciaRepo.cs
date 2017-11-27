using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dps2WebApi.Models
{
    public class OcorrenciaRepo : IOcorrencia
    {

        private List<Ocorrencias> _ocorrencias;

        public OcorrenciaRepo()
        {
            InicializaOcorrencias();
        }

        private void InicializaOcorrencias()
        {
            _ocorrencias = ocorrenciaOperacoes.ocorrenciasAbertas();
        }

        public IEnumerable<Ocorrencias> All
        {
            get
            {
                return _ocorrencias;
            }
        }

        public void acionamentoPanico(long cpf, float lati, float longi, int senha)
        {
            ocorrenciaOperacoes.InserirPanico(cpf, lati, longi, senha);
        }

        public void acionamentoEmergencia(long cpf, float lati, float longi, string historico)
        {
            ocorrenciaOperacoes.InserirEmergencia(cpf, lati, longi, historico);
        }

        public void acionamentoEmergenciaImagem(long cpf, float lati, float longi, Byte[] imagem, string historico)
        {
            ocorrenciaOperacoes.InserirEmergenciaImagem(cpf, lati, longi, imagem, historico);
        }

        public IEnumerable<Ocorrencias> ocorrenciasAbertas()
        {
         return   ocorrenciaOperacoes.ocorrenciasAbertas();
        }

    }
}
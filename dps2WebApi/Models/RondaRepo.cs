using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dps2WebApi.Models
{
    public class RondaRepo :IRondas
    {

        private List<Rondas> _rondas;

        public void InicializaRondas()
        {
            _rondas = RondaOperacoes.GetRondas();
        }

        public IEnumerable<Rondas> All
        {
            get
            {
                return _rondas;
            }
        }

        public void inserir(float longi, float lati, int cpf)
        {
            RondaOperacoes.Inserir(longi, lati, cpf);
        }

    }
}
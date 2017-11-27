using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dps2WebApi.Models
{
    public class RondaRepo :IRondas
    {

        private List<Rondas> _rondas;

        public RondaRepo()
        {
            InicializaRondas();
        }

        private void InicializaRondas()
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

        public void InserirRondas(float longi, float lati, long cpf)
        {
            RondaOperacoes.InserirRondas(longi, lati, cpf);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dps2WebApi.Models
{
    public interface IRondas
    {

        IEnumerable<Rondas> All { get; }
        void InserirRondas(float longi, float lati, long cpf);

    }
}
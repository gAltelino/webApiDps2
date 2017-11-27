using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dps2WebApi.Models
{
    public interface IRondas
    {

        IEnumerable<Rondas> All { get; }
        Rondas porCpf(int cpf);
        Rondas porHora(DateTime hora);
        Rondas porLocal(float longi, float lati);
        void inserir(float longi, float lati, int cpf);

    }
}
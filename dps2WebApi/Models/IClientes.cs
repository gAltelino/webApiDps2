using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dps2WebApi.Models
{
    public interface IClientes
    {
        void inserirPosicao(float lati, float longi, long cpf);
        
    }
}
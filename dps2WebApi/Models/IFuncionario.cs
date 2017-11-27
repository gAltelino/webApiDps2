using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dps2WebApi.Models
{
    public interface IFuncionario
    {
        string realizarLogin(long cpf, string senha);
        void cadastrarPessoa(long cpf, string senha, string nome, string tipo);
    }
}
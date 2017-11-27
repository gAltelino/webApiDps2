using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dps2WebApi.Models
{
    public class FuncionarioRepo : IFuncionario
    {

        public string realizarLogin(long cpf, string senha)
        {
            return FuncionarioOperacoes.realizarLogin(cpf, senha);
        }

        public void cadastrarPessoa(long cpf, string senha, string nome, string tipo)
        {
            FuncionarioOperacoes.cadastrarPessoa(cpf, senha, nome, tipo);
        }

    }
}
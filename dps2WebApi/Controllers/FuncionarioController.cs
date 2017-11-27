using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using dps2WebApi.Models;

namespace dps2WebApi.Controllers
{
    public class FuncionarioController : ApiController
    {
        private readonly IFuncionario funcionario;

        public FuncionarioController()
        {
            funcionario = new FuncionarioRepo();
        }

        [HttpGet]
        public string resultado(long cpf, string senha)
        {
            return funcionario.realizarLogin(cpf, senha);
        }

        [HttpPost]
        public void cadastrar(long cpf, string senha, string nome, string tipo)
        {
            funcionario.cadastrarPessoa(cpf, senha, nome, tipo);
        }

    }
}
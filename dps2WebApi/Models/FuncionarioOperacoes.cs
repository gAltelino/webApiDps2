using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;


namespace dps2WebApi.Models
{
    public class FuncionarioOperacoes
    {
        protected static string GetStringDb()
        {
            return ConfigurationManager.ConnectionStrings["mysqlDb"].ConnectionString;
        }

        //Receber dados para login - ok
        //enviar alerta - ok
        //enviar emergencia - ok
        //enviar posicao - ok
        //receber alerta e emergencia

        public static void cadastrarPessoa(long cpf, string senha, string nome, string tipo)
        {
            string senhaCriptografada;
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(senha);
            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            senhaCriptografada = sb.ToString();

            using (MySql.Data.MySqlClient.MySqlConnection con = new MySql.Data.MySqlClient.MySqlConnection(GetStringDb()))
            {
                using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
                {
                    cmd.Connection = con;
                    if (tipo == "funcionario")
                    {
                        cmd.CommandText = "INSERT INTO Funcionario (cpf, nome, senha, ativo) VALUES (@cpf, @nome, @senha, @ativo)";
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO Clientes (cpf, nome, senha, ativo) VALUES (@cpf, @nome, @senha, @ativo)";
                    }
                    cmd.Parameters.AddWithValue("@cpf", cpf);
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@senha", senhaCriptografada);
                    cmd.Parameters.AddWithValue("@ativo", 1);
                    Console.WriteLine(senha);
                    Console.Write(senha);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
            }
        }

        public static string realizarLogin(long cpf, string senha)
        {

            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(senha);
            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            senha = sb.ToString();

            using (MySql.Data.MySqlClient.MySqlConnection con = new MySql.Data.MySqlClient.MySqlConnection(GetStringDb()))
            {
                con.Open();
                using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM funcionario WHERE cpf=@cpf AND senha=@senha and ativo=1";
                    cmd.Parameters.AddWithValue("@cpf", cpf);
                    cmd.Parameters.AddWithValue("@senha", senha);
                    using (MySql.Data.MySqlClient.MySqlDataReader rdF = cmd.ExecuteReader())
                    {
                        if (rdF.HasRows == true)
                        {
                            return "funcionario";
                        }
                    }

                    cmd.Parameters.Clear();
                    cmd.CommandText = "SELECT * FROM clientes WHERE cpf=@cpf AND senha=@senha and ativo=1";
                    cmd.Parameters.AddWithValue("@cpf", cpf);
                    cmd.Parameters.AddWithValue("@senha", senha);
                    using (MySql.Data.MySqlClient.MySqlDataReader rdC = cmd.ExecuteReader())
                    {
                        if (rdC.HasRows == true)
                        {
                            return "cliente";
                        }
                    }

                }
                return "nothing";
            }
        }
    }
}
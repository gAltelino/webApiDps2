using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace dps2WebApi.Models
{
    public class ocorrenciaOperacoes
    {

        protected static string GetStringDb()
        {
            return ConfigurationManager.ConnectionStrings["mysqlDb"].ConnectionString;
        }

        public static void InserirPanico(long cpf, float lati, float longi, int senha)
        {
            using (MySql.Data.MySqlClient.MySqlConnection con = new MySql.Data.MySqlClient.MySqlConnection(GetStringDb()))
            {
                using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO ocorrencias (cpf_cliente, datahora, latitude, longitude, senha_utilizada) VALUES (@cpf_cliente, @datahora, @latitude, @longitude, @senha)", con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@cpf_cliente", cpf);
                    cmd.Parameters.AddWithValue("@datahora", DateTime.Now);
                    cmd.Parameters.AddWithValue("@latitude", lati);
                    cmd.Parameters.AddWithValue("@longitude", longi);
                    cmd.Parameters.AddWithValue("@senha", senha);


                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Clone();
                }
            }
        }

        public static void InserirEmergencia(long cpf, float lati, float longi, string historico)
        {
            using (MySql.Data.MySqlClient.MySqlConnection con = new MySql.Data.MySqlClient.MySqlConnection(GetStringDb()))
            {
                using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO ocorrencias (cpf_cliente, datahora, latitude, longitude, historico) VALUES (@cpf_cliente, @datahora, @latitude, @longitude, @historico)", con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@cpf_cliente", cpf);
                    cmd.Parameters.AddWithValue("@datahora", DateTime.Now);
                    cmd.Parameters.AddWithValue("@latitude", lati);
                    cmd.Parameters.AddWithValue("@longitude", longi);
                    cmd.Parameters.AddWithValue("@historico", historico);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Clone();
                }
            }
        }

        public static void InserirEmergenciaImagem(long cpf, float lati, float longi, Byte[] imagem,
            string historico)
        {
            using (MySql.Data.MySqlClient.MySqlConnection con = new MySql.Data.MySqlClient.MySqlConnection(GetStringDb()))
            {
                using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO ocorrencias (cpf_cliente, datahora, latitude, longitude, historico, imagem) VALUES (@cpf_cliente, @datahora, @latitude, @longitude, @historico, @imagem)", con))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@cpf_cliente", cpf);
                    cmd.Parameters.AddWithValue("@datahora", DateTime.Now);
                    cmd.Parameters.AddWithValue("@latitude", lati);
                    cmd.Parameters.AddWithValue("@longitude", longi);
                    cmd.Parameters.AddWithValue("@historico", historico);
                    cmd.Parameters.AddWithValue("@imagem", imagem);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Clone();
                }
            }
        }

        public static List<Ocorrencias> ocorrenciasAbertas()
        {
            List<Ocorrencias> _ocorrencias = new List<Ocorrencias>();
            using (MySql.Data.MySqlClient.MySqlConnection con = new MySql.Data.MySqlClient.MySqlConnection(GetStringDb()))
            {
                con.Open();
                using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT clientes.nome AS nome, ocorrencias.datahora AS dataHora, ocorrencias.latitude AS latitude" +
                    ", ocorrencias.longitude AS longitude, ocorrencias.senha_utilizada AS senhaUtilizada, ocorrencias.historico AS historico" +
                    " FROM ocorrencias INNER JOIN clientes ON ocorrencias.cpf_cliente = clientes.cpf WHERE cpf_funcionario IS NULL";

                    using (MySql.Data.MySqlClient.MySqlDataReader read = cmd.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            var ocorrencias = new Ocorrencias();
                            ocorrencias.nomeCliente = Convert.ToString(read["nome"]);
                            ocorrencias.datahora = Convert.ToDateTime(read["dataHora"]);
                            ocorrencias.latitude = Convert.ToSingle(read["latitude"]);
                            ocorrencias.longitude = Convert.ToSingle(read["longitude"]);
                            //ocorrencias.senha_utilizada = Convert.ToInt32(read["senhaUtilizada"]);
                            ocorrencias.historico = Convert.ToString(read["historico"]);
                            _ocorrencias.Add(ocorrencias);
                        }
                    }
                    return _ocorrencias;
                }
            }
        }
    }
}
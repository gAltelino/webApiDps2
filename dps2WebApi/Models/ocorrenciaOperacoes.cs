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


    }
}
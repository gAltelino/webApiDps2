using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace dps2WebApi.Models
{
    public class RondaOperacoes
    {

  

        public static List<Rondas> GetRondas()
        {

            MySql.Data.MySqlClient.MySqlConnection conexao = new MySql.Data.MySqlClient.MySqlConnection("Server=//localhost:3306;Database=dps;Uid=newuser;Pwd=123;");
            List<Rondas> _rondas = new List<Rondas>();

            conexao.Open();
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM Rondas", conexao))
            {
                using(MySql.Data.MySqlClient.MySqlDataReader read = cmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        var Rondas = new Rondas();
                        Rondas.cpf_ronda = Convert.ToInt32(read["cpf_ronda"]);
                        Rondas.datahora = Convert.ToDateTime(read["datahora"]);
                        Rondas.id = Convert.ToInt32(read["id"]);
                        Rondas.latitude = Convert.ToSingle(read["latitude"]);
                        Rondas.longitude = Convert.ToSingle(read["longitude"]);
                        _rondas.Add(Rondas);
                    }
                }
                return _rondas;
            }
        }

        public static void Inserir(float longi, float lati, int cpf)
        {
            MySql.Data.MySqlClient.MySqlConnection conexao = new MySql.Data.MySqlClient.MySqlConnection("Server=//localhost:3306;Database=dps;Uid=newuser;Pwd=123;");

            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO rondas (cpf_ronda, datahora, latitude, longitude) VALUES (@cpf, @data, @lati, @longi)", conexao))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@cpf", cpf);
                cmd.Parameters.AddWithValue("@data", DateTime.Now);
                cmd.Parameters.AddWithValue("@lati", lati);
                cmd.Parameters.AddWithValue("@longi", longi);

                conexao.Open();
                cmd.ExecuteNonQuery();
                conexao.Clone();
            }


        }

    }
}
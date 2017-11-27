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

        protected static string GetStringDb()
        {
            return ConfigurationManager.ConnectionStrings["mysqlDb"].ConnectionString;
        }


        public static List<Rondas> GetRondas()
        {

            List<Rondas> _rondas = new List<Rondas>();
            using (MySql.Data.MySqlClient.MySqlConnection con = new MySql.Data.MySqlClient.MySqlConnection(GetStringDb()))
            {

                Console.Write(con);

                con.Open();
                using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM Rondas", con))
                {
                    using (MySql.Data.MySqlClient.MySqlDataReader read = cmd.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            var Rondas = new Rondas();
                            Rondas.cpf_ronda = Convert.ToInt64(read["cpf_ronda"]);
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
        }

        public static void InserirRondas(float longi, float lati, float cpf)
        {
            using (MySql.Data.MySqlClient.MySqlConnection con = new MySql.Data.MySqlClient.MySqlConnection(GetStringDb()))
            {
                using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO rondas (cpf_ronda, datahora, latitude, longitude) VALUES (@cpf, @data, @lati, @longi)", con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@cpf", cpf);
                    cmd.Parameters.AddWithValue("@data", DateTime.Now);
                    cmd.Parameters.AddWithValue("@lati", lati);
                    cmd.Parameters.AddWithValue("@longi", longi);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Clone();
                }
            }

        }


    }
}
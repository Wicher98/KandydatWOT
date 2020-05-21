using System;
using System.Data.SqlClient;
using System.Text;
using static System.String;

namespace KandydatWOT.Models
{
    public class DbConnector
    {
        private SqlConnectionStringBuilder connect()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "dwot.database.windows.net";
            builder.UserID = "patryk";
            builder.Password = "C3AIo*8s?tUq?d#*as8g";
            builder.InitialCatalog = "Kandydaci";

            return builder;
        }
        
        public bool try_login(string user, string password)
        {
            using (SqlConnection connection = new SqlConnection(connect().ConnectionString))
            {
                var sb = new StringBuilder();
                sb.Append("SELECT EMAIL, HASLO, ID_TYP FROM Uzytkownicy");
                var sql = sb.ToString();

                using (var command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            /*Console.Write(reader.GetString(0));
                            Console.Write("\n");
                            Console.Write(user);
                            Console.Write("\n");
                            Console.Write(reader.GetString(1));
                            Console.Write("\n");
                            Console.Write(password);
                            Console.Write("\n");*/
                            Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                            var temp = reader.GetString(0);
                            if (String.Equals(temp,user))
                            {
                                Console.WriteLine("Mam krwa konto");
                                return true;
                            }
                        }
                        return false;
                    }
                }
            } 
           
        }
    }
}
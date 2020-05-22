using System.Data.SqlClient;

namespace KandydatWOT.Models
{
    public class DbConnector
    {
        public string Connect_String()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "dwot.database.windows.net";
            builder.UserID = "patryk";
            builder.Password = "C3AIo*8s?tUq?d#*as8g";
            builder.InitialCatalog = "Kandydaci";

            return builder.ToString();
        }
    }
}
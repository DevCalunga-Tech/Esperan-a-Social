using System.Data.SqlClient;

namespace EsperancaSocial.Desktop.Data
{
    public class Conexao
    {
        private static string connectionString =
            "Server=DESKTOP-F9I6S6K;Database=EsperancaSocial;Trusted_Connection=True;";

        public static SqlConnection ObterConexao()
        {
            return new SqlConnection(connectionString);
        }
    }
}

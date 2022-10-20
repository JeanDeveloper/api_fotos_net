using System.Data.SqlClient;


namespace ApiSolgisFotos.Utilidades
{
    public class BdConnection
    {
        
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(Startup.Configuration.GetSection("ConnectionString").Value);
        }

    }
}

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Fiap.Project.R4.Persistence.Repositories
{
    public  class Connection
    {
        public Connection()
        {

        }

        public SqlConnection ConnectionInstance() {
            var CS = "Server=tcp:xamarimdados.database.windows.net,1433;Initial Catalog=xamarim;Persist Security Info=False;User ID=adminxamarim;Password=!@avt2021;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            return new SqlConnection(CS);
        }

    }
}

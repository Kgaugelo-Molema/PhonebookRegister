using System.Data.Common;
using System.Data.SqlClient;

namespace PhonebookTests
{
    public class PhonebookRepository
    {
        private readonly SqlConnection _connection;

        public PhonebookRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public int SaveEntry(Contact payload)
        {
            var sqlCmd = $"INSERT Entry (Name, PhoneNumber) VALUES('{payload.Name}', '{payload.PhoneNumber}')";
            var command = new SqlCommand(sqlCmd, _connection);
            return command.ExecuteNonQuery();
        }
    }
}
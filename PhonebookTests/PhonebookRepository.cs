using System;
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

        public int SavePhonebook(Phonebook phonebook)
        {
            var sqlCmd = $"INSERT Phonebook (Name, EntryId) VALUES('{phonebook.Name}', '{phonebook.EntryId}')";
            var command = new SqlCommand(sqlCmd, _connection);
            return command.ExecuteNonQuery();
        }

        public void ClearData(Guid entryId)
        {
            var sqlCmd = $"DELETE Phonebook WHERE EntryId = '{entryId}'";
            var command = new SqlCommand(sqlCmd, _connection);
            command.ExecuteNonQuery();

            sqlCmd = $"DELETE Entry WHERE Id = '{entryId}'";
            command.CommandText = sqlCmd;
            command.ExecuteNonQuery();
        }
    }
}
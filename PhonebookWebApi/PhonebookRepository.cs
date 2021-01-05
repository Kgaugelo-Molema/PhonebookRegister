using System;
using System.Data.SqlClient;

namespace PhonebookWebApi
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
            ClearEntry(payload.Id);
            var sqlCmd = $"INSERT Entry (Id, Name, PhoneNumber) VALUES('{payload.Id}', '{payload.Name}', '{payload.PhoneNumber}')";
            var command = new SqlCommand(sqlCmd, _connection);
            return command.ExecuteNonQuery();
        }

        public int SavePhonebook(Phonebook phonebook)
        {
            ClearPhonebook(phonebook.EntryId);
            var sqlCmd = $"INSERT Phonebook (Name, EntryId) VALUES('{phonebook.Name}', '{phonebook.EntryId}')";
            var command = new SqlCommand(sqlCmd, _connection);
            return command.ExecuteNonQuery();
        }

        private void ClearPhonebook(Guid entryId)
        {
            var sqlCmd = $"DELETE Phonebook WHERE EntryId = '{entryId}'";
            var command = new SqlCommand(sqlCmd, _connection);
            command.ExecuteNonQuery();
        }

        private void ClearEntry(Guid entryId)
        {
            var sqlCmd = $"DELETE Entry WHERE Id = '{entryId}'";
            var command = new SqlCommand(sqlCmd, _connection);
            command.ExecuteNonQuery();
        }
    }
}
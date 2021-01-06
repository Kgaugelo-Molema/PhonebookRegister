using System;
using System.Collections.Generic;
using System.Data;
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
            _connection.Open();
            var command = new SqlCommand(sqlCmd, _connection);
            var result = command.ExecuteNonQuery();
            _connection.Close();
            return result;
        }

        public int SavePhonebook(Phonebook phonebook)
        {
            ClearPhonebook(phonebook.EntryId);
            _connection.Open();
            var sqlCmd = $"INSERT Phonebook (Name, EntryId) VALUES('{phonebook.Name}', '{phonebook.EntryId}')";
            var command = new SqlCommand(sqlCmd, _connection);
            var result = command.ExecuteNonQuery();
            _connection.Close();
            return result;
        }

        private void ClearPhonebook(Guid entryId)
        {
            var sqlCmd = $"DELETE Phonebook WHERE EntryId = '{entryId}'";
            _connection.Open();
            var command = new SqlCommand(sqlCmd, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
        }

        private void ClearEntry(Guid entryId)
        {
            var sqlCmd = $"DELETE Entry WHERE Id = '{entryId}'";
            _connection.Open();
            var command = new SqlCommand(sqlCmd, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
        }

        public IEnumerable<dynamic> GetEntries()
        {
            _connection.Open();
            var sqlCmd = "SELECT  p.EntryId, p.Name [Phonebook], e.Name, e.PhoneNumber FROM Entry e JOIN Phonebook p ON e.Id = p.EntryId";
            var command = new SqlCommand(sqlCmd, _connection);
            var reader = command.ExecuteReader();

            var entries = new List<dynamic>();
            while (reader.Read())
            {
                var entry =
                    new
                    {
                        Phonebook = reader.GetString("Phonebook"),
                        EntryId = reader.GetGuid("EntryId"),
                        Name = reader.GetString("Name"),
                        PhoneNumber = reader.GetString("PhoneNumber")
                    };

                entries.Add(entry);
            }
            _connection.Close();

            return entries;
        }
    }
}
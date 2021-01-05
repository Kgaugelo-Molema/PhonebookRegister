using System;
using System.Data.SqlClient;
using Xunit;

namespace PhonebookTests
{
    public class PhonebookEntryTests
    {
        private static SqlConnection _connection;
        private static PhonebookRepository _repository;

        private const string _entryId = "972573b2-77fb-4db2-8f56-3c9d422e29ab";

        public PhonebookEntryTests()
        {
            _connection = new SqlConnection("Data Source=.;Initial Catalog=Phonebook;Integrated Security=True;Pooling=False");
            _repository = new PhonebookRepository(_connection);

            _connection.Open();
            var entryId = Guid.Parse(_entryId);
            _repository.ClearData(entryId);
        }

        [Theory]
        [InlineData("Joe", "011 123 4567")]
        public void GivenContact_WhenAddingEntry_SavePayload(string name, string phoneNumber)
        {
            var entryId = Guid.Parse(_entryId);
            var contact = new Contact { Id = entryId, Name = name, PhoneNumber = phoneNumber };
            int result;

            result = _repository.SaveEntry(contact);
            Assert.Equal(1, result);
        }

        [Theory]
        [InlineData("Clients", _entryId)]
        public void GivenEntryId_WhenAddingPhonebook_SavePayload(string name, string entryId)
        {
            int result;

            var phonebook = new Phonebook { Name = name, EntryId = Guid.Parse(entryId) };
            result = _repository.SavePhonebook(phonebook);
            Assert.Equal(1, result);
        }
    }
}

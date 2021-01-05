using System;
using System.Data.SqlClient;
using Xunit;

namespace PhonebookTests
{
    public class PhonebookEntryTests
    {
        [Theory]
        [InlineData("Joe", "011 123 4567")]
        public void GivenContact_WhenAddingEntry_SavePayload(string name, string phoneNumber)
        {
            var contact = new Contact { Name = name, PhoneNumber = phoneNumber };
            var connection = new SqlConnection("Data Source=.;Initial Catalog=Phonebook;Integrated Security=True;Pooling=False");
            int result;
            using (connection)
            {
                connection.Open();
                var repo = new PhonebookRepository(connection);
                result = repo.SaveEntry(contact);
            }
            Assert.Equal(1, result);
        }
    }
}

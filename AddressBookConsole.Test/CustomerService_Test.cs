using AddressBookConsole.Interface;
using AddressBookConsole.Model;
using AddressBookConsole.Service.ContactService;
using Moq;

namespace AddressBookConsole.Test
{
    public class CustomerService_Test
    {

        /// <summary>
        /// Mocks the FileService to load the file with contacts.
        /// Gets the contacts.
        /// Checks if it returned a list with contacts and if it is not null.
        /// </summary>
        [Fact]
        public void GetContacts_Should_ReturnContacts()
        {
            // Arrange
            var mockFileService = new Mock<IFileService>();
            mockFileService.Setup(fs => fs.LoadContacts()).Returns([]);

            var contactService = new ContactService(mockFileService.Object);

            // Act
            var result = contactService.GetContacts();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<ContactModel>>(result);
        }

        /// <summary>
        /// Mocks the FileService to load the file with contacts.
        /// Adds a new contact and saves it to the list.
        /// Checks if the new contact is in the list.
        /// </summary>

        [Fact]
        public void AddContact_Should_AddContact()
        {
            // Arrange
            var mockFileService = new Mock<IFileService>();
            mockFileService.Setup(fs => fs.LoadContacts()).Returns([]);
            
            var contactService = new ContactService(mockFileService.Object);

            var newContact = new ContactModel
            {
                FirstName = "Marko",
                LastName = "Misimovic",
                PhoneNumber = "07012345",
                Email = "Marko@email.com",
                StreetName = "MarkoGatan 5",
                PostalCode = "12345",
                City = "Halmstad"
            };

            // Act
            contactService.AddContact(newContact);

            // Assert
            Assert.Contains(newContact, contactService.GetContacts());
        }
    }

}

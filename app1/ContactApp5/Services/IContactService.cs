using ContactApp5.Models;

namespace ContactApp5.Services;

public interface IContactService
{
    Task SaveContactAsync(Contact contact);
    Task<List<Contact>> GetAllContactsAsync();
}
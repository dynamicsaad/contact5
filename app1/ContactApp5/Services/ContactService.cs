using ContactApp5.Models;

namespace ContactApp5.Services;

public class ContactService : IContactService
{
    private readonly string _filePath;

    public ContactService(IWebHostEnvironment env)
    {
        _filePath = Path.Combine(env.ContentRootPath, "contacts.txt");
    }

    public async Task SaveContactAsync(Contact contact)
    {
        var contactLine = $"{contact.Name},{contact.PhoneNumber}{Environment.NewLine}";
        await File.AppendAllTextAsync(_filePath, contactLine);
    }

    public async Task<List<Contact>> GetAllContactsAsync()
    {
        if (!File.Exists(_filePath))
        {
            return new List<Contact>();
        }

        var lines = await File.ReadAllLinesAsync(_filePath);
        return lines.Select(line => 
        {
            var parts = line.Split(',');
            return new Contact { Name = parts[0], PhoneNumber = parts[1] };
        }).ToList();
    }

}
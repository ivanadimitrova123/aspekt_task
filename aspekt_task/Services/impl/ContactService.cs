using aspekt_task.Models;

namespace aspekt_task.Services.impl;

public class ContactService : IContactService
{
    private readonly ApplicationDbContext _dbContext;

    public ContactService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Contact GetContactById(int contactId)
    {
        return _dbContext.Contacts.FirstOrDefault(c => c.ContactId == contactId);
    }

    public List<Contact> GetAllContacts()
    {
        return _dbContext.Contacts.ToList();
    }

    public int CreateContact(Contact contact)
    { 
        _dbContext.Contacts.Add(contact);
        _dbContext.SaveChanges();
        return contact.ContactId;
    }

   /* public Company UpdateContact(Contact contact)
    {
        var existingContact = _dbContext.Contacts.FirstOrDefault(c => c.ContactId == contact.ContactId);

        if (existingContact != null)
        {
            existingContact.ContactName = contact.ContactName;
            _dbContext.SaveChanges();
        }

        return existingContact?.Company;
    }*/

    public void DeleteContact(int contactId)
    {
        var contactToRemove = _dbContext.Contacts.FirstOrDefault(c => c.ContactId == contactId);

        if (contactToRemove != null)
        {
            _dbContext.Contacts.Remove(contactToRemove);
            _dbContext.SaveChanges();
        }
    }
}
using aspekt_task.Models;
using Microsoft.EntityFrameworkCore;

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
        
        if (contact.CompanyId != 0)
        {
            var company = _dbContext.Companies.Find(contact.CompanyId);
            if (company != null)
            {
                company.Contacts.Add(contact);
            }
        }

        if (contact.CountryId != 0)
        {
            var country = _dbContext.Countries.Find(contact.CountryId);
            if (country != null)
            {
                country.Contacts.Add(contact);
            }
        }

        _dbContext.SaveChanges();
        return contact.ContactId;
    }
    public Company UpdateContact(Contact contact)
    {
        var existingContact = _dbContext.Contacts.FirstOrDefault(c => c.ContactId == contact.ContactId);

        if (existingContact != null)
        {
            existingContact.ContactName = contact.ContactName;
            _dbContext.SaveChanges();
        }

        var companyId = existingContact?.CompanyId ?? 0;
        var associatedCompany = _dbContext.Companies
            .FirstOrDefault(c => c.CompanyId == companyId);

        return associatedCompany;
    }
    
   /*public Contact UpdateContact(Contact contact)
    {
        var existingContact = _dbContext.Contacts.FirstOrDefault(c => c.ContactId == contact.ContactId);

        if (existingContact != null)
        {
            existingContact.ContactName = contact.ContactName;
            _dbContext.SaveChanges();
        }

        return existingContact;
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
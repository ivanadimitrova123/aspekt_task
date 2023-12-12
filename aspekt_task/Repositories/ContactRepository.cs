using aspekt_task.Models;
using Microsoft.EntityFrameworkCore;

namespace aspekt_task.Repositories;


public class ContactRepository : IContactRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ContactRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public List<dynamic> GetContactsWithCompanyAndCountry()
    {
        var contacts  = _dbContext.Contacts
            .Join(
                _dbContext.Companies,
                contact => contact.CompanyId,
                company => company.CompanyId,
                (contact, company) => new
                {
                    ContactId = contact.ContactId,
                    ContactName = contact.ContactName,
                    CompanyId = contact.CompanyId,
                    CompanyName = company.CompanyName, 
                    CountryId = contact.CountryId
                }
            )
            .Join(
                _dbContext.Countries,
                combined => combined.CountryId,
                country => country.CountryId,
                (combined, country) => new
                {
                    ContactId = combined.ContactId,
                    ContactName = combined.ContactName,
                    CompanyId = combined.CompanyId,
                    CompanyName = combined.CompanyName,
                    CountryId = combined.CountryId,
                    CountryName = country.CountryName 
                }
            )
            .ToList<dynamic>();


 
        return contacts;
    }

    public List<Contact> FilterContact(int countryId, int companyId)
    {
        return _dbContext.Contacts
            .Where(c => c.CountryId == countryId && c.CompanyId == companyId)
            .ToList();    
    }
}
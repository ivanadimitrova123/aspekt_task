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
    
    //TODO
    public Contact GetContactWithCompanyAndCountry()
    {
        throw new NotImplementedException();
    }

    public List<Contact> FilterContact(int countryId, int companyId)
    {
        return _dbContext.Contacts
            .Where(c => c.CountryId == countryId && c.CompanyId == companyId)
            .ToList();    
    }
}
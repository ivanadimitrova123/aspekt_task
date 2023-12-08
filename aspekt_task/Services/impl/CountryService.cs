using aspekt_task.Models;
using Microsoft.EntityFrameworkCore;

namespace aspekt_task.Services.impl;

public class CountryService : ICountryService
{
    private readonly ApplicationDbContext _dbContext;

    public CountryService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Country GetCountryById(int countryId)
    {
        return _dbContext.Countries.FirstOrDefault(c => c.CountryId == countryId);
    }

    public List<Country> GetAllCountries()
    {
        return _dbContext.Countries.ToList();
    }

    public int CreateCountry(Country country)
    {
        _dbContext.Countries.Add(country);
        _dbContext.SaveChanges();
        return country.CountryId;    
    }

    /*public Company UpdateCountry(Country country)
    {
        var existingCountry = _dbContext.Countries
            .Include(c => c.Contacts)
            .ThenInclude(contact => contact.Company)
            .FirstOrDefault(c => c.CountryId == country.CountryId);

        if (existingCountry != null)
        {
            existingCountry.CountryName = country.CountryName;

            // Update the associated Company if needed
            foreach (var contact in existingCountry.Contacts)
            {
                contact.Company.CompanyName = country.Company.CompanyName;
            }

            _dbContext.SaveChanges();
            return existingCountry.Contacts.FirstOrDefault()?.Company;
        }

        return null;  
    }*/

    public void DeleteCountry(int countryId)
    {
        var countryToRemove = _dbContext.Countries.FirstOrDefault(c => c.CountryId == countryId);

        if (countryToRemove != null)
        {
            _dbContext.Countries.Remove(countryToRemove);
            _dbContext.SaveChanges();
        }
    }
}
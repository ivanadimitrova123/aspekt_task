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
        return _dbContext.Countries
            .Where(c => c.CountryId == countryId)
            .Include(c => c.Contacts)
            .FirstOrDefault();
    }

    public List<Country> GetAllCountries()
    {
        return _dbContext.Countries.Include(c => c.Contacts).ToList();
    }

    public int CreateCountry(Country country)
    {
        _dbContext.Countries.Add(country);
        _dbContext.SaveChanges();
        return country.CountryId;    
    }
    
    public Country UpdateCountry(Country country)
    { 
        var existingCountry = _dbContext.Countries
            .FirstOrDefault(c => c.CountryId == country.CountryId);

        if (existingCountry != null) 
        { 
            existingCountry.CountryName = country.CountryName; 
            _dbContext.SaveChanges();
        }
    
        return existingCountry;
    }

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
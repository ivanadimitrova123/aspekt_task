using aspekt_task.Models;

namespace aspekt_task.Services.impl;

public class CompanyService : ICompanyService
{
    private readonly ApplicationDbContext _dbContext;

    public CompanyService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public Company GetCompanyById(int companyId)
    {
        return _dbContext.Companies.FirstOrDefault(c => c.CompanyId == companyId);
    }
    
    public List<Company> GetAllCompanies()
    {
        return _dbContext.Companies.ToList();
    }

    public int CreateCompany(Company company)
    {
        _dbContext.Companies.Add(company);
        _dbContext.SaveChanges();
        return company.CompanyId;
    }

    public Company UpdateCompany(Company company)
    {
        var existingCompany = _dbContext.Companies.FirstOrDefault(c => c.CompanyId == company.CompanyId);

        if (existingCompany != null)
        {
            existingCompany.CompanyName = company.CompanyName;
            _dbContext.SaveChanges();
        }

        return existingCompany;
    }

    public void DeleteCompany(int companyId)
    {
        var companyToRemove = _dbContext.Companies.FirstOrDefault(c => c.CompanyId == companyId);
        if (companyToRemove != null)
        {
            _dbContext.Companies.Remove(companyToRemove);
            _dbContext.SaveChanges();
        }
    }
}
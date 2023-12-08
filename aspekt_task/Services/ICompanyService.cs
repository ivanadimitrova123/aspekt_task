using aspekt_task.Models;

namespace aspekt_task.Services;

public interface ICompanyService
{
    public Company GetCompanyById(int companyId);
    List<Company> GetAllCompanies();
    int CreateCompany(Company company);
    Company UpdateCompany(Company company);
    void DeleteCompany(int companyId);
}
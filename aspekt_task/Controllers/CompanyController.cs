using aspekt_task.Models;
using aspekt_task.Services;
using Microsoft.AspNetCore.Mvc;

namespace aspekt_task.Controllers;

[ApiController]
[Route("api/companies")]
public class CompanyController : ControllerBase
{
    private readonly ICompanyService _companyService;
    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }
    
    [HttpGet("{companyId}")]
    public ActionResult<Company> GetCompanyById(int companyId)
    {
        var company = _companyService.GetCompanyById(companyId);
        if (company == null)
        {
            return NotFound();
        }

        return Ok(company);
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<Company>> GetAllCompanies()
    {
        var companies = _companyService.GetAllCompanies();
        return Ok(companies);
    }
    
    [HttpPost]
    public ActionResult<int> CreateCompany([FromBody] Company company)
    {
        var companyId = _companyService.CreateCompany(company);
        return CreatedAtAction(nameof(GetCompanyById), new { companyId }, companyId);
    }
    
    [HttpPut("{companyId}")]
    public ActionResult<Company> UpdateCompany(int companyId, [FromBody] Company company)
    {
        if (companyId != company.CompanyId)
        {
            return BadRequest("Company Id not found.");
        }

        var updatedCompany = _companyService.UpdateCompany(company);
        if (updatedCompany == null)
        {
            return NotFound();
        }

        return Ok(updatedCompany);
    }
    
    [HttpDelete("{companyId}")]
    public ActionResult DeleteCompany(int companyId)
    {
        _companyService.DeleteCompany(companyId);
        return NoContent();
    }

   
}
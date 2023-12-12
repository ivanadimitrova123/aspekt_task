using aspekt_task.Models;
using aspekt_task.Services;
using Microsoft.AspNetCore.Mvc;

namespace aspekt_task.Controllers;


[ApiController]
[Route("api/countries")]
public class CountryController : ControllerBase
{
    private readonly ICountryService _countryService;

    public CountryController(ICountryService countryService)
    {
        _countryService = countryService;
    }

    [HttpGet("{countryId}")]
    public ActionResult<Country> GetCountryById(int countryId)
    {
        var country = _countryService.GetCountryById(countryId);
        if (country == null)
        {
            return NotFound();
        }

        return Ok(country);
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<Country>> GetAllCountries()
    {
        var countries = _countryService.GetAllCountries();
        return Ok(countries);
    }
    
    [HttpPost]
    public ActionResult<int> CreateCountry([FromBody] Country country)
    {
        var countryId = _countryService.CreateCountry(country);
        return CreatedAtAction(nameof(GetCountryById), new { countryId }, countryId);
    }
    
   
    [HttpPut("{countryId}")] 
    public ActionResult<Country> UpdateCountry(int countryId, [FromBody] Country country) 
    { 
        if (countryId != country.CountryId) 
        { 
            return BadRequest("Country Id in the URL does not match the one in the request body.");
        }
        var updatedCountry = _countryService.UpdateCountry(country); 
        if (updatedCountry == null) 
        { 
            return NotFound();
        }
        
        return Ok(updatedCountry);
    }
     

    [HttpDelete("{countryId}")]
    public ActionResult DeleteCountry(int countryId)
    {
        _countryService.DeleteCountry(countryId);
        return NoContent();
    }
    
}
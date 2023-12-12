using aspekt_task.Models;

namespace aspekt_task.Services;

public interface ICountryService
{
    Country GetCountryById(int countryId);
    List<Country> GetAllCountries();
    int CreateCountry(Country country);
   Company UpdateCountry(Country country);
   //Country UpdateCountry(Country country);

    void DeleteCountry(int countryId);
}

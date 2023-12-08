using aspekt_task.Models;

namespace aspekt_task.Repositories;

public interface IContactRepository 
{
    Contact GetContactWithCompanyAndCountry();
    List<Contact> FilterContact(int countryId, int companyId);
}
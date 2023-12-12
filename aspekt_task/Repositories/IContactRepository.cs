using aspekt_task.Models;

namespace aspekt_task.Repositories;

public interface IContactRepository 
{
    List<dynamic> GetContactsWithCompanyAndCountry();
    List<Contact> FilterContact(int countryId, int companyId);
}
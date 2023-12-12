using aspekt_task.Models;
namespace aspekt_task.Services;

public interface IContactService
{
    public Contact GetContactById(int contactId);

    List<Contact> GetAllContacts();
    int CreateContact(Contact contact);
   Company UpdateContact(Contact contact);
   //Contact UpdateContact(Contact contact);
    void DeleteContact(int contactId);
}

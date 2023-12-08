using aspekt_task.Models;
using aspekt_task.Repositories;
using aspekt_task.Services;
using Microsoft.AspNetCore.Mvc;

namespace aspekt_task.Controllers;

[ApiController]
[Route("api/contacts")]
public class ContactController : ControllerBase
{
    private readonly IContactService _contactService;
    private readonly IContactRepository _contactRepository;

    public ContactController(IContactService contactService,IContactRepository contactRepository)
    {
        _contactService = contactService;
        _contactRepository = contactRepository;
    }

    [HttpGet("{contactId}")]
    public ActionResult<Contact> GetContactById(int contactId)
    {
        var contact = _contactService.GetContactById(contactId);
        if (contact == null)
        {
            return NotFound();
        }

        return Ok(contact);
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<Contact>> GetAllContacts()
    {
        var contacts = _contactService.GetAllContacts();
        return Ok(contacts);
    }
    
    [HttpPost]
    public ActionResult<int> CreateContact([FromBody] Contact contact)
    {
        var contactId = _contactService.CreateContact(contact);
        return CreatedAtAction(nameof(GetContactById), new { contactId }, contactId);
    }
    //TODO
    /*
        [HttpPut("{contactId}")]
        public ActionResult<Contact> UpdateContact(int contactId, [FromBody] Contact contact)
        {
            if (contactId != contact.ContactId)
            {
                return BadRequest("Contact Id in the URL does not match the one in the request body.");
            }

            var updatedContact = _contactService.UpdateContact(contact);
            if (updatedContact == null)
            {
                return NotFound();
            }

            return Ok(updatedContact);
        }
        */
    
    [HttpDelete("{contactId}")]
    public ActionResult DeleteContact(int contactId)
    {
        _contactService.DeleteContact(contactId);
        return NoContent();
    }
    
    [HttpGet("filter")]
    public ActionResult<IEnumerable<Contact>> FilterContacts([FromQuery] int countryId, [FromQuery] int companyId)
    {
        try
        {
            var filteredContacts = _contactRepository.FilterContact(countryId, companyId);
            return Ok(filteredContacts);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error filtering contacts: {ex.Message}");
        }
    }
}
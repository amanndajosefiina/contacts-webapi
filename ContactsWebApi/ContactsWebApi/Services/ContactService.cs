using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsWebApi.Models;
using ContactsWebApi.Repositories;

namespace ContactsWebApi.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactsRepository _contactsRepository;

        public ContactService(IContactsRepository contactsRepository)
        {
            _contactsRepository = contactsRepository;
        }


        public List<Contact> GetContacts()
        {
            return _contactsRepository.Get();
        }

        public Contact GetContactById(int id)
        {
            return _contactsRepository.Get(id);
        }

        public Contact CreateContact(Contact contact)
        {
            return _contactsRepository.Create(contact);
        }

        public Contact UpdateContact(int id, Contact contact)
        {
            var savedContact = _contactsRepository.Get(id);
            if (savedContact == null)
            {
                throw new Exception("Contact not found.");
            }
            else
            {
                return _contactsRepository.Update(contact);
            }
        }

        public void DeleteContact(int id)
        {
                _contactsRepository.Delete(id);
        }
    }
}

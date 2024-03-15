using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda_Mirzav3.AgendaMirzaDB;
using Microsoft.EntityFrameworkCore; 

namespace Agenda_Mirzav3.Service.DAO
{
    public class DAO_Contact
    {
        public IEnumerable<Contact> GetAllContacts()
        {
            using (var context = new AgendaMirzaContext()) 
            {
                var allContacts = context.Contacts.ToList();
               
                return allContacts;
            }
        }

        public void AddContact(Contact contact)
        {
            using (var context = new AgendaMirzaContext())
            {
                context.Contacts.Add(contact);
                context.SaveChanges();
            }
        }

        public void DelateContact(int id)
        {
            using (var context = new AgendaMirzaContext())
            {
                var contact = context.Contacts.Find(id);   
                context.Contacts.Remove(contact);
                context.SaveChanges();
            }
        }

        public void UpdateContact(Contact contact)
        {
            using (var context = new AgendaMirzaContext())
            {
                context.Contacts.Update(contact);
                context.SaveChanges();  
            }
        }
    }
}
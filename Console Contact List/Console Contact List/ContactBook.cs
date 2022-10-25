using System;
using System.Collections.Generic;
using System.Linq;

namespace Console_Contact_List
{
    internal class ContactBook
    {
        public List<Contact> Contacts { get; set; } = new List<Contact>(); 

        private void Display_Contact_Info(Contact contact)
        {
            Console.WriteLine($"***Name:  {contact.Name}\n***Number: {contact.Number} \n\n");
        }

        private void Display_All_Contacts_Info(List<Contact> contacts)
        {
            Console.WriteLine("*** Your contact list:  ***\n");
            int count = 1; 
            foreach (var contact in contacts)
            {
                Console.WriteLine($"***  {count}  ***");
                Display_Contact_Info(contact);
                count++; 
            }
        }
        public void Add_Contact(Contact contact, string number)
        {
            List<Contact> numbers = Contacts.Where(e => e.Get_Numbers() == number).ToList();

            foreach (var numberUsed in numbers)
            {
                Display_Contact_Info(contact);
                Console.WriteLine("\nTwo users cannot have the same number!"); 
            }

            if(Contacts.Contains(contact) == true)
            {
                Console.WriteLine("User already exists!"); 
            }

            if(numbers.Count == 0)
            {
                Contacts.Add(contact);
                Console.WriteLine("Contact successfully added!"); 
            }
        }

        public void Display_Contact(string number)
        {
            var contact = Contacts.FirstOrDefault(c => c.Number == number);

            if (contact == null)
            {
                Console.WriteLine("Contact was not found.");
            }
            else
            {
                Display_Contact_Info(contact);            
            }
        }

        public void Display_All_Contacts()
        { 
            Display_All_Contacts_Info(Contacts);
        }

        public void Display_Matching_Contacts(string userSearch)
        {
            //checking if users seach phrase is contained within the contacts. If true -> adding result to a list 
            var matchingContacts = Contacts.Where(c => c.Name.Contains(userSearch)).ToList();
            Display_All_Contacts_Info(matchingContacts); 
        }

        public void Remove_Contact()
        {

            Display_All_Contacts_Info(Contacts);

            Console.Write("Input the number of the user you want to remove(1/2/3/.../etc): ");
            int userChoice = Convert.ToInt32(Console.ReadLine());

            if(userChoice > Contacts.Count || userChoice <= 0)
            {
                Console.WriteLine("Wrong index!");
            }

            for (int i = 0; i < Contacts.Count; i++)
            {
                if ((i + 1) == userChoice)
                {
                    Contacts.Remove(Contacts.ElementAt(0));
                    Console.WriteLine("Contact has been removed!");
                }
            }

        }
    }
}

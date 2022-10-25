using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Contact_List
{
    internal class Contact
    {
        public Contact(string name, string number)
        {
            Name = name;
            Number = number;
        }
        public string Get_Numbers() => Number;
        public string Get_Name() => Name;
        public string Name { get; set; }    
        public string Number { get; set; }
    }
}

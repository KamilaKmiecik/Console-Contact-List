using System;

namespace Console_Contact_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var contactBook = new ContactBook();

            Console.Clear(); 
            Console.WriteLine("*** Welcome to the Contact List! ***\n");
            Console.WriteLine("*   1.Add contact                  *");
            Console.WriteLine("*   2.Search by number             *");
            Console.WriteLine("*   3.All contacts                 *");
            Console.WriteLine("*   4.Search contacts              *");
            Console.WriteLine("*   5.Remove contacts              *");
            Console.WriteLine("*   To exit press 'x'              *\n");
            Console.Write("*** Input your choice: ");
            var userInput = Console.ReadLine();
            Console.WriteLine("\n");

            //Infinite loop, user can access the information in one session 
            while (true)
            {
                    switch (userInput)
                {
                    case "1":

                        Console.WriteLine("Insert number: ");
                        var number = Console.ReadLine();
                        Console.WriteLine("Insert contact name: ");
                        var name = Console.ReadLine();

                        var newContact = new Contact(name, number);
                        int numberOfDigits = 0;

                        for (int i = 0; i < newContact.Number.Length; i++)
                        {
                            //Checking if user typed in numbers 0 through 9 
                            if ((newContact.Number[i] >= '0') && (newContact.Number[i] <= '9'))
                            {
                                //counting digits
                                numberOfDigits++;
                            }

                        }

                        if (numberOfDigits != 9)
                        {
                            Console.WriteLine($"\n\nA number must be 9 digits! Here's what you wrote: {number}");
                            Console.WriteLine("Try adding the contact again...\n");
                        }
                        else
                        {
                            contactBook.Add_Contact(newContact, number);
                        }

                        break;
                    case "2":

                        Console.WriteLine("Insert number: ");
                        var numberSearch = Console.ReadLine();

                        contactBook.Display_Contact(numberSearch);

                        break;
                    case "3":

                        contactBook.Display_All_Contacts();

                        break;
                    case "4":

                        Console.WriteLine("Insert contact name: ");
                        var nameSearch = Console.ReadLine();
                        contactBook.Display_Matching_Contacts(nameSearch);

                        break;
                    case "5":

                        Console.WriteLine("\n\nInput the user you are trying to remove: ");
                        contactBook.Remove_Contact(); 

                        break;
                    //User can either press lowercase 'x' or uppercase 'X'
                    case "x":
                    case "X":
                        return;

                    default:
                        Console.WriteLine("invalid input.");
                        break;
                }


                Console.Write("\n\n*** Input your choice: ");
                userInput = Console.ReadLine();
                Console.WriteLine("\n"); 
            } 
        }
    }
}

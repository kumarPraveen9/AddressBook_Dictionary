using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class Operations
    {
        public void addPerson()
        {
            Console.WriteLine("-------------Adding Operation-----------");
            Console.WriteLine("How many contacts u want to add: ");
            int n=Convert.ToInt32(Console.ReadLine());
            while(n>0)
            {
                Person person = new Person();
                Console.WriteLine("Enter the first name of Person: ");
                person.fname = Console.ReadLine();
                Console.WriteLine("Enter the last name of Person: ");
                person.lname = Console.ReadLine();
                Console.WriteLine("Enter the address of Person: ");
                person.addr = Console.ReadLine();
                Console.WriteLine("Enter the city of Person: ");
                person.city = Console.ReadLine();
                Console.WriteLine("Enter the state of Person: ");
                person.state = Console.ReadLine();
                Console.WriteLine("Enter the zip code of Person: ");
                person.zip = Console.ReadLine();
                Console.WriteLine("Enter the phone number of Person: ");
                person.phnumber = Console.ReadLine();
                Console.WriteLine("Enter the mail of Person: ");
                person.mail = Console.ReadLine();
                Console.WriteLine("\n");

                Program.Personlist.Add(person);
                n--;
            }
            Console.WriteLine("\n");
        }
        
       

        

    }

}

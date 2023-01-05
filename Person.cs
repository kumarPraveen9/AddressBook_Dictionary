using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class Person
    {

        public void PersonDetails()
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("Enter the first name of Person: ");
            string fname = Console.ReadLine();
            Console.WriteLine("Enter the last name of Person: ");
            string lname = Console.ReadLine();
            Console.WriteLine("Enter the address of Person: ");
            string addr = Console.ReadLine();
            Console.WriteLine("Enter the city of Person: ");
            string city = Console.ReadLine();
            Console.WriteLine("Enter the state of Person: ");
            string state = Console.ReadLine();
            Console.WriteLine("Enter the zip code of Person: ");
            string zip = Console.ReadLine();
            Console.WriteLine("Enter the phone number of Person: ");
            string phnumber = Console.ReadLine();
            Console.WriteLine("Enter the mail of Person: ");
            string mail = Console.ReadLine();
            Console.WriteLine("\n");

            AddressModel addressModel = new AddressModel(fname,lname,addr,city,state,zip,phnumber,mail);
            Console.WriteLine(addressModel.Contacts());
            Console.WriteLine("=========================================");

        }
    }
}

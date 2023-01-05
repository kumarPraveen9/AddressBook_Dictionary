using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class AddressBookArray
    {
        private Person[] People;
        public int NoOfpersons=0;

        public AddressBookArray()
        {
            People = new Person[100];
            
        }

        public void addPerson(int n)
        {
            while (NoOfpersons <n )
            {
                Console.WriteLine("Enter the Details of Person{0}: ",NoOfpersons);
                People[NoOfpersons] = new Person();
                People[NoOfpersons].PersonDetails();
                NoOfpersons++;
                
            }
        }
    }
}

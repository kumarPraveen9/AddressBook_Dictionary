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
        
        public void display()
        {
            Console.WriteLine("-------------Display Operation-----------");
            foreach (var p in Program.Personlist)
            {
                Console.WriteLine(p.fname);
                Console.WriteLine(p.lname);
                Console.WriteLine(p.addr);
                Console.WriteLine(p.city);
                Console.WriteLine(p.state);
                Console.WriteLine(p.zip);
                Console.WriteLine(p.phnumber);
                Console.WriteLine(p.mail);
                Console.WriteLine("\n");
            }
        }

           public void edit()
        {
            Console.WriteLine("-------------Edit Operation-----------");
            Console.WriteLine("Enter a number to edit");
            Console.WriteLine("1)firstname\t2)lastname\t3)address\t4)city\t5)state\t6)zip\t7)phonenumber\t8)mail");
            int K=Convert.ToInt16((Console.ReadLine()));
            switch(K)
            {
                case 1: Console.WriteLine("enter firstname");
                        string cfname=Console.ReadLine();
                       foreach(var p in Program.Personlist)
                       {
                        if (p.fname == cfname)
                        {
                            Console.WriteLine("enter updated firstname");
                            p.fname = Console.ReadLine();
                                }
                       }
                       break;
                case 2:
                    Console.WriteLine("enter lastname");
                    string clname = Console.ReadLine();
                    foreach (var p in Program.Personlist)
                    {
                        if (p.lname == clname)
                        {
                            Console.WriteLine("enter updated lasttname");
                            p.lname = Console.ReadLine();
                        }
                    }
                    break;
                case 3:
                    Console.WriteLine("enter address");
                    string caddr = Console.ReadLine();
                    foreach (var p in Program.Personlist)
                    {
                        if (p.addr == caddr)
                        {
                            Console.WriteLine("enter updated address");
                            p.addr = Console.ReadLine();
                        }
                    }
                    break;
                case 4:
                    Console.WriteLine("enter city");
                    string ccity = Console.ReadLine();
                    foreach (var p in Program.Personlist)
                    {
                        if (p.city == ccity)
                        {
                            Console.WriteLine("enter updated city");
                            p.city = Console.ReadLine();
                        }
                    }
                    break;
                case 5:
                    Console.WriteLine("enter state");
                    string cstate = Console.ReadLine();
                    foreach (var p in Program.Personlist)
                    {
                        if (p.state == cstate)
                        {
                            Console.WriteLine("enter updated state");
                            p.state = Console.ReadLine();
                        }
                    }
                    break;
                case 6:
                    Console.WriteLine("enter zip");
                    string czip = Console.ReadLine();
                    foreach (var p in Program.Personlist)
                    {
                        if (p.zip == czip)
                        {
                            Console.WriteLine("enter updated zip");
                            p.zip = Console.ReadLine();
                        }
                    }
                    break;
                case 7:
                    Console.WriteLine("enter phone number");
                    string cphnumber = Console.ReadLine();
                    foreach (var p in Program.Personlist)
                    {
                        if (p.phnumber == cphnumber)
                        {
                            Console.WriteLine("enter updated phone number");
                            p.phnumber = Console.ReadLine();
                        }
                    }
                    break;
                case 8:
                    Console.WriteLine("enter mail");
                    string cmail = Console.ReadLine();
                    foreach (var p in Program.Personlist)
                    {
                        if (p.mail == cmail)
                        {
                            Console.WriteLine("enter updated mail");
                            p.mail = Console.ReadLine();
                        }
                    }
                    break;
                default: Console.WriteLine("enter valid option");
                    break;
            }

        }

        public void delete()
        {
            Console.WriteLine("-------------Delete Operation-----------");
            Console.WriteLine("enter the Person name which you want to delete :");
            string cfname= Console.ReadLine();
            foreach (var p in Program.Personlist)
            {
                if (p.fname == cfname)
                {
                    Program.Personlist.Remove(p);
                    break;

                }
            }
        }

   }

}

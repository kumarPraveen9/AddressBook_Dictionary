using System;
using System.Collections;

namespace dict
{
    class Contacts
    {
        public string[] Array_of_Details = new string[8];
        public Contacts(string First, string Last, string Add, string City, string State, string Zip, string Phone, string Email)
        {
            Array_of_Details[0] = First;
            Array_of_Details[1] = Last;
            Array_of_Details[2] = Add;
            Array_of_Details[3] = City;
            Array_of_Details[4] = State;
            Array_of_Details[5] = Zip;
            Array_of_Details[6] = Phone;
            Array_of_Details[7] = Email;
        }
        public void Check()
        {
            Console.WriteLine("\nThe details for {0} {1} are:\nAddress: {2}\nCity: {3}\nState: {4}\n" +
                "Zip Code: {5}\nPhone Number: {6}\nEmail: {7}\n", Array_of_Details[0],
                Array_of_Details[1], Array_of_Details[2], Array_of_Details[3],
                Array_of_Details[4], Array_of_Details[5], Array_of_Details[6], Array_of_Details[7]);
        }
    }
    class AddressBookMain
    {
        Dictionary<string, string[]> Page = new Dictionary<string, string[]>();
        List<string> persons = new List<string>();
        Dictionary<string, List<string>> cityPerson = new Dictionary<string, List<string>>();
        Dictionary<string, List<string>> statePerson = new Dictionary<string, List<string>>();

        public void AddAddress()
        {
            string First_Name;
            try
            {
                Console.Write("Enter First Name: ");
                First_Name = Console.ReadLine();
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("First name can not be null.");
            }
            if (checkDuplicate(First_Name))
                throw new Exception("Another person by the same name exists in the Address Book");
            Console.Write("Enter Last Name: ");
            string Last_Name = Console.ReadLine();
            Console.Write("Enter Address: ");
            string Address = Console.ReadLine();
            Console.Write("Enter City: ");
            string City = Console.ReadLine();
            Console.Write("Enter State: ");
            string State = Console.ReadLine();
            Console.Write("Enter Zip : ");
            string Zip_Code = Console.ReadLine();
            Console.Write("Enter Phone Number: ");
            string Phone_Number = Console.ReadLine();
            Console.Write("Enter Email Address: ");
            string Email = Console.ReadLine();
            Contacts Record = new Contacts(First_Name, Last_Name, Address, City, State, Zip_Code,
                Phone_Number, Email);
            Page.Add(First_Name, Record.Array_of_Details);
            Record.Check();
            if (!cityPerson.Keys.Contains(City.ToLower()))
            {
                persons.Add(First_Name);
                cityPerson.Add(City.ToLower(), persons);
                persons.Clear();
            }
            else
            {
                cityPerson.TryGetValue(City.ToLower(), out persons);
                if (!persons.Contains(First_Name))
                    persons.Add(First_Name);
                cityPerson.Remove(City.ToLower());
                cityPerson.Add(City.ToLower(), persons);
                persons.Clear();
            }
            if (!statePerson.Keys.Contains(State.ToLower()))
            {
                persons.Add(First_Name);
                statePerson.Add(State.ToLower(), persons);
                persons.Clear();
            }
            else
            {
                statePerson.TryGetValue(State.ToLower(), out persons);
                if (!persons.Contains(First_Name))
                    persons.Add(First_Name);
                statePerson.Remove(State.ToLower());
                statePerson.Add(State.ToLower(), persons);
                persons.Clear();
            }
        }
        public bool checkDuplicate(string name) => (Page.ContainsKey(name)) ? true : false;
        public void Edit()
        {
            Console.Write("\nEnter the first name for the contact: ");
            string First_Name = Console.ReadLine();
            if (!Page.ContainsKey(First_Name))
                throw new ArgumentNullException("No such person in the Addressbook");
            Page.TryGetValue(First_Name, out string[] Edit_Detail);
            Console.Write("Enter a number to edit first name(1), last name(2), address(3), " +
                "city(4), state(5), zip code(6), \nphone number(7) or email(8): ");
            int Index = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the new value: ");
            Edit_Detail[Index - 1] = Console.ReadLine();
            Contacts Record = new Contacts(
                Edit_Detail[0], Edit_Detail[1],
                Edit_Detail[2], Edit_Detail[3],
                Edit_Detail[4], Edit_Detail[5],
                Edit_Detail[6], Edit_Detail[7]);
            Page.Remove(First_Name);
            Page.Add(Edit_Detail[0], Edit_Detail);
            Record.Check();
        }
        public void Delete()
        {
            Console.Write("\nEnter the first name for the contact: ");
            string First_Name = Console.ReadLine();
            if (!Page.ContainsKey(First_Name))
                throw new ArgumentNullException("No such person in the Addressbook");
            Page.TryGetValue(First_Name, out string[] Edit_Detail);
            Page.Remove(First_Name);
            Console.WriteLine("Address entry for {0} {1} was removed.", Edit_Detail[0], Edit_Detail[1]);
        }
        public void Display()
        {
            Console.Write("\nEnter the First name of the contact you want to display (\"all\" to " +
                "disdplay all contacts): ");
            string Name = Console.ReadLine();
            if (Name != "all")
            {
                Display(Name);
            }
            else
            {
                foreach (string Key in Page.Keys)
                {
                    Display(Key);
                }
            }
        }
        public void Display(string Name)
        {
            Page.TryGetValue(Name, out string[] Edit_Detail);
            Contacts Record = new Contacts(
                Edit_Detail[0], Edit_Detail[1],
                Edit_Detail[2], Edit_Detail[3],
                Edit_Detail[4], Edit_Detail[5],
                Edit_Detail[6], Edit_Detail[7]);
            Record.Check();
        }
        public int search(string name, int cityOrState)
        {
            int num = 0;
            foreach (string[] details in Page.Values)
            {
                if (cityOrState == 1)
                {
                    Func<string[], bool> InCity = details => details[3].ToLower() == name.ToLower();
                    if (InCity(details))
                    {
                        Console.WriteLine(details[0]);
                        num++;
                    }
                }
                else if (cityOrState == 2)
                {
                    Func<string[], bool> InState = details => details[4].ToLower() == name.ToLower();
                    if (InState(details))
                    {
                        Console.WriteLine(details[0]);
                        num++;
                    }
                }
            }
            return num;
        }
        public void viewContacts()
        {
            Console.Write("Search by (City/State): ");
            string cityOrState = Console.ReadLine().ToLower();
            if (cityOrState.ToLower() == "city")
            {
                Console.Write("Enter the name of the city: ");
                string city = Console.ReadLine();
                cityPerson.TryGetValue(city, out persons);
                foreach (string name in persons)
                    Display(name);
                persons.Clear();
            }
            else if (cityOrState.ToLower() == "state")
            {
                Console.Write("Enter the name of the state: ");
                string state = Console.ReadLine();
                statePerson.TryGetValue(state, out persons);
                foreach (string name in persons)
                    Display(name);
                persons.Clear();
            }
        }
        public void Access_to_Addressbook()
        {
            int Control;
            do
            {
                Console.WriteLine("\n1 to Add Contacts");
                Console.WriteLine("2 to Edit Contacts");
                Console.WriteLine("3 to Delete Contacts");
                Console.WriteLine("4 to Display Contacts");
                Console.WriteLine("0 to EXIT");
                Console.Write("Enter a value: ");
                Control = Convert.ToInt32(Console.ReadLine());
                char Confirmation = 'y';
                switch (Control)
                {
                    case 0:
                        break;
                    case 1:
                        Console.Write("\nEnter the number of address you want to add: ");
                        int Number = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < Number; i++)
                        {
                            AddAddress();
                        }
                        break;
                    case 2:
                        while (Confirmation == 'y')
                        {
                            Edit();
                            Console.Write("\nEdit another? (y/n): ");
                            Confirmation = Convert.ToChar(Console.ReadLine());
                        }
                        break;
                    case 3:
                        while (Confirmation == 'y')
                        {
                            Delete();
                            Console.Write("\nDelete another? (y/n): ");
                            Confirmation = Convert.ToChar(Console.ReadLine());
                        }
                        break;
                    case 4:
                        while (Confirmation == 'y')
                        {
                            Display();
                            Console.Write("Display another? (y/n): ");
                            Confirmation = Convert.ToChar(Console.ReadLine());
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid Entry");
                        break;
                }
            } while (Control != 0);
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program");
            AddressBookMain Relatives = new AddressBookMain();
            AddressBookMain Work = new AddressBookMain();
            int Control;
            do
            {
                Console.WriteLine("\nChoose an Address Book: ");
                Console.WriteLine("1 for Relatives Address book");
                Console.WriteLine("2 for Work Address Book");
                Console.WriteLine("3 to Search across all Address books");
                Console.WriteLine("4 to View contacts in a City or State");
                Console.WriteLine("0 to EXIT");
                Control = Convert.ToInt32(Console.ReadLine());
                switch (Control)
                {
                    case 1:
                        Relatives.Access_to_Addressbook();
                        break;
                    case 2:
                        Work.Access_to_Addressbook();
                        break;
                    case 3:
                        Console.Write("Search by (City/State): ");
                        string cityOrState = Console.ReadLine().ToLower();
                        string name = "";
                        int num = 0;
                        if (cityOrState.ToLower() == "city")
                        {
                            Console.Write("Enter the name of the city: ");
                            name = Console.ReadLine();
                            num = 1;
                        }
                        else if (cityOrState.ToLower() == "state")
                        {
                            Console.Write("Enter the name of the state: ");
                            name = Console.ReadLine();
                            num = 2;
                        }
                        Console.WriteLine("Names of people living in {0} are:\n", name);
                        int result1 = Relatives.search(name, num);
                        int result2 = Work.search(name, num);
                        int result= result1+result2;
                        Console.WriteLine("Number of people in {0} are {1}", name, result);
                        break;
                    case 4:
                        Console.WriteLine("\n1 for Relatives");
                        Console.WriteLine("2 for Work");
                        Console.WriteLine("0 to Exit");
                        Console.Write("Pick an address book: ");
                        int book = Convert.ToInt32(Console.ReadLine());
                        switch (book)
                        {
                            case 1:
                                Relatives.viewContacts();
                                break;
                            case 2:
                                Work.viewContacts();
                                break;
                            default:
                                break;
                        }
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Invalid Entry");
                        break;
                }
            } while (Control != 0);
        }
    }
}

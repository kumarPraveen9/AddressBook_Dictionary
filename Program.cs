namespace AddressBook
{
    class Program
    {
        public static List<Person> Personlist=new List<Person>();
        public static void Main(string[] args)
        {
            int z = 1;
            Operations operations = new Operations();

            
            while (z > 0)
            {
                Console.WriteLine("Enter a number to do which operation:");
                Console.WriteLine("1)Add_Contact\t2)Display_Contacts\t3)Edit_Contact\t4)Delete_Contact\t5)Exit");
                int r=Convert.ToInt32(Console.ReadLine());
           
            
                switch (r)
                {
                    case 1:
                        operations.addPerson();
                        break;
                    case 2:
                        operations.display();
                        
                        break;

                    case 3:
                        operations.edit();
                        break;
                    case 4:
                        operations.delete();
                        break;
                    case 5:
                        z = 0;
                        break;
                    default:
                        Console.WriteLine("Oops a valid number to do which operation:");
                        break;

                }
            }
            









        }
    }
}

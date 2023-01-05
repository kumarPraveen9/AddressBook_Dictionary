namespace AddressBook
{
    class Program
    {
        public static void Main(string[] args)
        {
            
            
            Operations operations = new Operations();
            operations.addPerson();
            operations.display();
            operations.edit();
            operations.delete();
        }
    }
}

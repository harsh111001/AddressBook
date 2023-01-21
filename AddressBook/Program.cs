using Microsoft.VisualBasic;
using System.Runtime.InteropServices;

namespace AddressBook
{
    public class Contact
    {
        public string firstName;
        public string lastName;
        public string address;
        public string city;
        public string state;
        public string zipcode;
        public string phoneNumber;
        public string email;

        public Contact(string firstName, string lastName, string address, string city, string state, string zipcode, string phoneNumber, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zipcode = zipcode;
            this.phoneNumber = phoneNumber;
            this.email = email;
        }
        public void setAddress(string new_address)
        {
            this.address = new_address;
        }
        public void setCity(string new_city)
        {
            this.city = new_city;
        }
        public void setState(string new_state)
        {
            this.state = new_state;
        }
        public void setZipCode(string new_zipcode)
        {
            this.zipcode = new_zipcode;
        }
        public void setPhoneNumber(string new_phonenumber)
        {
            this.phoneNumber= new_phonenumber;
        }
        public void setEmail(string new_email)
        {
            this.email = new_email;
        }
        public void print()
        {
            Console.WriteLine($"contact-> first name : {this.firstName} last name : {this.lastName} address : {this.address} city : {this.city} state : {this.state} zipcode : {this.zipcode} phonenumber : {this.phoneNumber} email : {this.email}");
        }
    }
    public class AddressBook
    {
        private List<Contact> contactList;
        private Dictionary<string, Contact> contactDictionary;

        public AddressBook()
        {
            //contactList = new List<Contact>();
            contactDictionary = new Dictionary<string, Contact>();
        }
        public void addContact(string firstName, string lastName, string address, string city, string state, string zipcode, string phoneNumber, string email)
        {
            Contact detail = new Contact(firstName,lastName,address,city,state,zipcode,phoneNumber,email);
            //contactList.Add(detail);
            contactDictionary[firstName] = detail;
        }
        public void editContact(string firstName)
        {
            //Console.WriteLine("enter the first name to edit ");
            //string editcontact=Console.ReadLine();
            //Contact contact= contactDictionary[editcontact];
            Console.WriteLine("what would you like to edit :");
            Console.WriteLine("enter 1 for address");
            Console.WriteLine("enter 2 for city");
            Console.WriteLine("enter 3 for state");
            Console.WriteLine("enter 4 for zipcode");
            Console.WriteLine("enter 5 for phonenumber");
            Console.WriteLine("enter 6 for email");
            int option=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter new entry ");
            string newentry=Console.ReadLine();
            switch(option)
            {
                case 1:
                    contactDictionary[firstName].setAddress(newentry);
                    break;
                case 2:
                    contactDictionary[firstName].setCity(newentry); 
                    break;
                case 3:
                    contactDictionary[firstName].setState(newentry);
                    break;
                case 4:
                    contactDictionary[firstName].setZipCode(newentry);
                    break;
                case 5:
                    contactDictionary[firstName].setPhoneNumber(newentry);
                    break;
                case 6:
                    contactDictionary[firstName].setEmail(newentry);
                    break;
                default:
                    Console.WriteLine("wrong option");
                    break;
            }
            
        }
        public void printAllContacts()
        {
            foreach(var item in this.contactDictionary)
            {
                item.Value.print();
            }
        }
        public void deleteContact(string firstName) 
        {
            this.contactDictionary.Remove(firstName);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, this is addressbook");
            AddressBook contactlist= new AddressBook();
            contactlist.addContact("harsh","jain","abdnagar","sgr","mp","47983","823879312","hars@.com");
            contactlist.printAllContacts();
            contactlist.editContact("harsh");
            contactlist.addContact("sparsh", "pakaain", "abdgarh", "blr", "karnataka", "462283", "275163312", "sparars@.com");
            contactlist.printAllContacts();
            contactlist.deleteContact("harsh");
            Console.WriteLine("after deletion");
            contactlist.printAllContacts();
        }
    }
}
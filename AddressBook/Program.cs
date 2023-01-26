using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Transactions;

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
    public static class AddressBookMap
    {
        public static Dictionary<string,AddressBook> map=new Dictionary<string, AddressBook>();
        public static Dictionary<string,List<Contact>> citypersonmap= new Dictionary<string, List<Contact>>();
        public static Dictionary<string, List<Contact>> statepersonmap = new Dictionary<string, List<Contact>>();
        public static void Allpersoninacityacrossalladdressbooks(string city)
        {
            foreach(var person in citypersonmap[city])
            {
                person.print();
            }
        }

        public static void Allpersoninastateacrossalladdressbooks(string state)
        {
            foreach (var person in statepersonmap[state])
            {
                person.print();
            }
        }
        public static int countAllpersoninacityacrossalladdressbooks(string city)
        {
            return citypersonmap[city].Count;
        }
        public static int countAllpersoninastateacrossalladdressbooks(string state)
        {
            return statepersonmap[state].Count;
        }
    }
    public class AddressBook
    {
        //private List<Contact> contactList;
        private Dictionary<string, Contact> contactDictionary;
        private Dictionary<string, List<Contact>> contacttocityDictionary;
        private Dictionary<string, List<Contact>> contacttostateDictionary;
        public string name;

        public void sortbyname()
        {
            foreach (KeyValuePair<string, Contact> contact in contactDictionary.OrderBy(key => key.Value.firstName))
            {
                contact.Value.print();
            }
        }
        public void sortbycity()
        {
            foreach (KeyValuePair<string, Contact> contact in contactDictionary.OrderBy(key => key.Value.city))
            {
                contact.Value.print();
            }
        }
        public void sortbystate()
        {
            foreach (KeyValuePair<string, Contact> contact in contactDictionary.OrderBy(key => key.Value.state))
            {
                contact.Value.print();
            }
        }
        public void sortbyzip()
        {
            foreach (KeyValuePair<string, Contact> contact in contactDictionary.OrderBy(key => key.Value.zipcode))
            {
                contact.Value.print();
            }
        }
        public AddressBook(string name)
        {
            //contactList = new List<Contact>();
            contactDictionary = new Dictionary<string, Contact>();
            contacttostateDictionary= new Dictionary<string, List<Contact>>();
            contacttocityDictionary= new Dictionary<string, List<Contact>>();
            this.name = name;
            AddressBookMap.map[name]= this;
        }
        public void addContact(string firstName, string lastName, string address, string city, string state, string zipcode, string phoneNumber, string email)
        {
            Contact detail = new Contact(firstName,lastName,address,city,state,zipcode,phoneNumber,email);
            //contactList.Add(detail);
            if (contactDictionary.ContainsKey(firstName))
            {
                Console.WriteLine($"already a contact with {firstName} exists");
                return;
            }
            contactDictionary[firstName] = detail;
            if(contacttocityDictionary.ContainsKey(detail.city)) 
            {
                contacttocityDictionary[detail.city].Add(detail);
            }
            else
            {
                contacttocityDictionary[detail.city] = new List<Contact>();
                contacttocityDictionary[detail.city].Add(detail);
            }
            if (contacttostateDictionary.ContainsKey(detail.state))
            {
                contacttostateDictionary[detail.state].Add(detail);
            }
            else
            {
                contacttostateDictionary[detail.state] = new List<Contact>();
                contacttostateDictionary[detail.state].Add(detail);
            }
            if (AddressBookMap.citypersonmap.ContainsKey(detail.city))
            {
                AddressBookMap.citypersonmap[detail.city].Add(detail);
            }
            else
            {
                AddressBookMap.citypersonmap[detail.city]=new List<Contact>();
                AddressBookMap.citypersonmap[detail.city].Add(detail);
            }
            if (AddressBookMap.statepersonmap.ContainsKey(detail.state))
            {
                AddressBookMap.statepersonmap[detail.state].Add(detail);
            }
            else
            {
                AddressBookMap.statepersonmap[detail.state]=new List<Contact>();
                AddressBookMap.statepersonmap[detail.state].Add(detail);
            }
        }
        public void contatctinparticularcityinthisaddressbook(string city) 
        {
            foreach(var person in contacttocityDictionary[city]) 
            {
                person.print();
            }
        }
        public void contatctinparticularstateinthisaddressbook(string state)
        {
            foreach (var person in contacttostateDictionary[state])
            {
                person.print();
            }
        }
        public int countAllpersoninacityacrossalladdressbooks(string city)
        {
            return contacttocityDictionary[city].Count;
        }
        public int countcontatctinparticularstateinthisaddressbook(string state)
        {
            return contacttostateDictionary[state].Count;
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
        public void addMultipleContacts()
        {
            Console.WriteLine("enter number of contacts you would like to add : ");
            int n=Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter details");
                Console.WriteLine("First Name");
                string first_name=Console.ReadLine();
                Console.WriteLine("Last Name");
                string last_name = Console.ReadLine();
                Console.WriteLine("Address");
                string address = Console.ReadLine();
                Console.WriteLine("City");
                string city = Console.ReadLine();
                Console.WriteLine("State");
                string state = Console.ReadLine();
                Console.WriteLine("Zip code");
                string zipcode = Console.ReadLine();
                Console.WriteLine("Phone Number");
                string phonenumber = Console.ReadLine();
                Console.WriteLine("Email");
                string email = Console.ReadLine();
                addContact(first_name,last_name,address,city,state,zipcode,phonenumber,email);
            }
        }
        public void writeToJson()
        {
            Console.WriteLine("Writing data to Json file .......");
            string path = @"C:\Users\223089249\source\repos\AddressBook\AddressBook.json";
            string result = JsonConvert.SerializeObject(contactDictionary.Values);
            File.WriteAllText(path, result);
            Console.WriteLine("Done");
        }
        public void readFromJson()
        {
            try
            {
                Console.WriteLine("Reading data from Json file .......");
                string path = @"C:\Users\223089249\source\repos\AddressBook\AddressBook.json";
                string toProcess = File.ReadAllText(path);
                var result = JsonConvert.DeserializeObject<List<Contact>>(toProcess);
                foreach (var item in result)
                {
                    item.print();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //Console.WriteLine("Done");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, this is addressbook");
            AddressBook contactlist= new AddressBook("contactlist");
            contactlist.addContact("harsh","jain","h.no.-100","sagar","mp","47983","823879312","hars@.com");
            //contactlist.printAllContacts();
            contactlist.addContact("sparsh", "palak", "park avenue street", "bangalore", "karnataka", "462283", "275163312", "sparars@.com");
            contactlist.addContact("Aarsh", "palak", "park avenue street", "bangalore", "karnataka", "462283", "275163312", "sparars@.com");
            //contactlist.writeToJson();
            contactlist.readFromJson();
            
        }
    }
}
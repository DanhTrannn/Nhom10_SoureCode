using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using database;
using datastructure;

namespace CustomersManager
{
    public class CustomerManager
    {
        private DataStructure _data;
        private DataBase db;
        public CustomerManager(DataStructure data)
        {
            _data = data;
            db = new DataBase();
        }
        public void AddCustomer(Customer newCustomer)
        {
            _data.customers.AddLast(newCustomer);
            Console.WriteLine("Customer is successfully added!");
            db.saveCustomerData(_data);
        }
        public void RemoveCustomer(string targetID)
        {
            if (_data.customers.size == 0)
            {
                Console.WriteLine("Customer list is empty, can't remove!!");
                return;
            }
            else
            {
                Customer deletedCustomer = _data.customers.Find(c => c.id == targetID);
                if (!deletedCustomer.Equals(default(Customer)))
                {
                    _data.customers.Remove(c => c.id == targetID);
                    Console.WriteLine("Customer is successfully removed!");
                    db.saveCustomerData(_data);
                }
                else
                {
                    Console.WriteLine("Customer with ID "+ targetID + " is not found!");
                }
            }
        }
        public void UpdateCustomer(Customer updateCustomer)
        {
            bool update = _data.customers.Update(c => c.id == updateCustomer.id, updateCustomer);
            if (update)
            {
                Console.WriteLine("Customer is successfully updated!");
                db.saveCustomerData(_data);
            }
            else
            {
                Console.WriteLine("Customer with ID " + updateCustomer.id + " is not found!");
            }
        }
        public void FindCustomer(string targetPhoneNumber) 
        {
            Customer res = _data.customers.Find(c => c.phoneNumber == targetPhoneNumber);
            if (!res.Equals(default(Customer)))
            {
                Console.WriteLine("Customer is found!");
                res.ToString();
            }
            else
            {
                Console.WriteLine("Customer with phone number " + targetPhoneNumber + " is not found!");
            }
        }
        public void DisplayCustomer()
        {
            _data.customers.Display();
        }
    }
}

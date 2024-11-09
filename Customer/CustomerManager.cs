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
        public void AddCustomer(Customer customer)
        {
            _data.Customers.AddLast(customer);
            Console.WriteLine("Customer is successfully added!");
            db.saveCustomerData(_data);
        }
        public void RemoveCustomer(string Id)
        {
            if (_data.Customers.size == 0)
            {
                Console.WriteLine("Customer list is empty, can't remove!!");
                return;
            }
            else
            {
                Customer delCustomer = _data.Customers.Find(c => c.id == Id);
                if (!delCustomer.Equals(default(Customer)))
                {
                    _data.Customers.Remove(c => c.id == Id);
                    Console.WriteLine("Customer is successfully deleted!");
                    db.saveCustomerData(_data);
                }
                else
                {
                    Console.WriteLine("Can found customer: "+ Id + " !");
                }
            }
        }
        public void UpdateCustomer(Customer updateCustomer)
        {
            bool update = _data.Customers.Update(c => c.id == updateCustomer.id, updateCustomer);
            if (update)
            {
                Console.WriteLine("Customer is successfully updated!");
                db.saveCustomerData(_data);
            }
            else
            {
                Console.WriteLine("Customer " + updateCustomer.id + " is not found!");
            }
        }
        public void FindCustomer(string data) 
        {
            Customer res = _data.Customers.Find(c => c.phoneNumber == data);
            if (!res.Equals(default(Customer)))
            {
                Console.WriteLine("Customer is found!");
                res.ToString();
            }
            else
            {
                Console.WriteLine("Can not find customer!");
            }
        }
        public void DisplayCustomer()
        {
            _data.Customers.Display();
        }
    }
}

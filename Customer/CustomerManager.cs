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
            Console.WriteLine("Da them khach hang thanh cong");
            db.saveCustomerData(_data);
        }
        public void RemoveCustomer(string Id)
        {
            if (_data.Customers.size == 0)
            {
                Console.WriteLine("Danh sach khach hang rong, khong the xoa!");
                return;
            }
            else
            {
                Customer delCustomer = _data.Customers.Find(c => c.id == Id);
                if (!delCustomer.Equals(default(Customer)))
                {
                    _data.Customers.Remove(c => c.id == Id);
                    Console.WriteLine("Da xoa khach hang!");
                    db.saveCustomerData(_data);
                }
                else
                {
                    Console.WriteLine("Khong tim thay khach hang co ID: "+Id);
                }
            }
        }
        public void UpdateCustomer(Customer updateCustomer)
        {
            bool update = _data.Customers.Update(c => c.id == updateCustomer.id, updateCustomer);
            if (update)
            {
                Console.WriteLine("Khach hang da duoc cap nhat thanh cong!");
                db.saveCustomerData(_data);
            }
            else
            {
                Console.WriteLine("Khong tim thay khach hang co ID " + updateCustomer.id);
            }
        }
        public void FindCustomer(Customer find) 
        {
            Customer res = _data.Customers.Find(c => c.id == find.id);
            if (!res.Equals(default(Customer)))
            {
                Console.WriteLine("Da tim thay khach hang!");
                res.ToString();
            }
            else
            {
                Console.WriteLine("Khong tim thay khach hang!");
            }
        }
        public void DisplayCustomer()
        {
            _data.Customers.Display();
        }
    }
}

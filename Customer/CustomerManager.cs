using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
            Customer check = _data.customers.Find(c => c.id == newCustomer.id);
            if (check.Equals(default(Customer)))
            {
                _data.customers.AddLast(newCustomer);
                _data.undo.Push(new UndoAction("Add", newCustomer));
                Console.WriteLine("Customer is successfully added into list!");
                db.saveCustomerData(_data);
            }
            else
            {
                Console.WriteLine("Customer with ID: " + newCustomer.id + " already exist, can't add new one, only update!");
            }
        }
        public void RemoveCustomer(string targetID)
        {
            if (_data.customers.size == 0)
            {
                Console.WriteLine("Customers list is empty, can't remove!!");
                return;
            }
            else
            {
                // Lưu trữ khách hàng trước khi xoá
                Customer deletedCustomer = _data.customers.Find(c => c.id == targetID);
                // Nếu tìm thấy khách hàng có ID cần xoá
                if (!deletedCustomer.Equals(default(Customer)))
                {
                    _data.customers.Remove(c => c.id == targetID);
                    _data.undo.Push(new UndoAction("Remove", deletedCustomer));
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
            // Lưu trữ trạng thái khách hàng trước khi cập nhật
            Customer oldCustomer = _data.customers.Find(c => c.id == updateCustomer.id);
            bool update = _data.customers.Update(c => c.id == updateCustomer.id, updateCustomer);
            if (update)
            {
                _data.undo.Push(new UndoAction("Update", oldCustomer));
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
                Console.WriteLine(res);
            }
            else
            {
                Console.WriteLine("Customer with phone number " + targetPhoneNumber + " is not found!");
            }
        }
        public void enterIntoLine(Customer newCustomer)
        {
            _data.line.Enqueue(newCustomer);
            Console.WriteLine("Customer is now in line waiting to check in!");
        }
        public void showFirstInLine()
        {
            if (_data.line.Count > 0)
            {
                Customer temp = _data.line.Peek();
                Console.WriteLine("Information of first customer in line: ");
                Console.WriteLine(temp);
            }
            else
            {
                Console.WriteLine("Line is empty, no one is waiting now!");
            }
        }
        public void checkOutComplete()
        {
            if (_data.line.Count > 0)
            {
                Customer temp = _data.line.Dequeue();
                AddCustomer(temp);
            }
            else
            {
                Console.WriteLine("Line is empty, there aren't any customers waiting!");
            }
        }
        public void showCustomerInLine()
        {
            if ( _data.line.Count > 0)
            {
                _data.line.Display();
            }
            else
            {
                Console.WriteLine("Line is empty, there aren't any customers waiting!");
            }
        }
        public void DisplayCustomer()
        {
            if( _data.customers.size > 0)
            {
                _data.customers.Display();
            }
            else
            {
                Console.WriteLine("Nothing to display, please add new customer!");
            }
        }
        public void undo()
        {
            if(_data.undo.Count() > 0)
            {
                UndoAction lastAction = _data.undo.Pop();
                if(lastAction.action.Equals("Add"))
                {
                    _data.customers.Remove(c => c.id == lastAction.oldcustomer.id);
                    Console.WriteLine("Undo successfully!");
                }else if(lastAction.action.Equals("Remove"))
                {
                    _data.customers.AddLast(lastAction.oldcustomer);
                    Console.WriteLine("Undo successfully!");
                }
                else if(lastAction.action.Equals("Update"))
                {
                    _data.customers.Update(c => c.id == lastAction.oldcustomer.id, lastAction.oldcustomer);
                    Console.WriteLine("Undo successfully!");
                }
                else
                {
                    Console.WriteLine("Unknown undo action.");
                }
                db.saveCustomerData(_data);
            }
            else
            {
                Console.WriteLine("Nothing to undo!");
            }
        }
    }
}

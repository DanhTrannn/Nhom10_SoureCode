using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using database;
using datastructure;
namespace Customer
{
    public class CustomerManager
    {
        private DataStructure _data;
        public CustomerManager(DataStructure data)
        {
            this._data = data;
        }
    }
}

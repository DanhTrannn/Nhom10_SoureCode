using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;
using DataStructure;
namespace Movies
{
    public class MoviesManager
    {
        private datastructure _data;
        public MoviesManager(datastructure data)
        {
            this._data = data;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Dictionary
    {
        public Dictionary<int, Movie> dictionary = new Dictionary<int, Movie>();
    }

    public class Movie
    {
        public string Title;
        public int Year;
    }    
}

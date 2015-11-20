using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OOP
{
    [TestClass]
    public class DictionaryTests
    {
        [TestMethod]
        public void Add()
        {
            Dictionary<string, Movie> dictio = new Dictionary<string, Movie>();

            Movie movie1 = new Movie();
            movie1.Title = "The Shawshank Redemption";
            movie1.Year = 1994;
            Movie movie2 = new Movie();
            movie2.Title = "The Godfather";
            movie2.Year = 1972;
            Movie movie3 = new Movie();
            movie3.Title = "The Dark Knight";
            movie3.Year = 2008;

            dictio.Add(movie1.GetHashCode(), movie1);
            dictio.Add(movie2.GetHashCode(), movie2);
            //dictio.dictionary.Add(movie3.GetHashCode(), movie3);
            dictio.ContainsKey(movie3.Title);         
        }
    }
}

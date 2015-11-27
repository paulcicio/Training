using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bookmaker;

namespace BettingTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddAnEventToTheCurrentOffer()
        {
            DateTime date = new DateTime(2015, 11, 28, 15, 00, 00);
            Event match1 = new Event();
            match1.Code = 3326;
            match1.Match = "U Cluj vs Medias";
            match1.Date = date;
            Events.CurrentOffer.Add(match1);
            Events.CurrentOffer.Add(match1);

        }
    }
}

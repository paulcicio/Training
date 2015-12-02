using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bookmaker;

namespace BettingTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void EmptyOffer()
        {
            Events events = new Events();
            int numberOfEventsInOffer = events.CurrentOffer.Capacity;
            Assert.AreEqual(0, numberOfEventsInOffer);

        }
        [TestMethod]
        public void AddAnEventToTheCurrentOffer()
        {
            DateTime date = new DateTime(2015, 11, 28, 15, 00, 00);
            Event match1 = new Event();
            match1.Code = 3326;
            match1.Match = "U Cluj vs Medias";
            match1.Date = date;
            Events events = new Events();
            events.CurrentOffer.Add(match1);           

        }
        [TestMethod]
        public void AddMultipleEventsToTheCurrentOffer()
        {
            DateTime date = new DateTime(2015, 11, 28, 15, 00, 00);
            Event match1 = new Event();
            match1.Code = 3326;
            match1.Match = "U Cluj vs Medias";
            match1.Date = date;
            Events events = new Events();
            events.CurrentOffer.Add(match1);
            DateTime date2 = new DateTime(2015, 12, 02, 20, 00, 00);
            Event match2 = new Event();
            match2.Code = 307;
            match2.Match = "Bastia vs Bordeaux";
            match2.Date = date2;
            events.CurrentOffer.Add(match2);
        }
        [TestMethod]
        public void ShouldNotRemoveIfCurrentOfferIsEmpty()
        {            
            DateTime date = new DateTime(2015, 12, 02, 21, 45, 00);
            Event match = new Event();
            match.Code = 330;
            match.Match = "Southampton vs Liverpool";
            match.Date = date;
            Events events = new Events();
            events.CurrentOffer.Remove(match);
            int nr = events.CurrentOffer.Capacity;
            Assert.AreEqual(0, nr);
        }

        [TestMethod]
        public void ShouldRemoveAnEvent()
        {
            DateTime date = new DateTime(2015, 11, 28, 15, 00, 00);
            Event match1 = new Event();
            match1.Code = 3326;
            match1.Match = "U Cluj vs Medias";
            match1.Date = date;
            Events events = new Events();
            events.CurrentOffer.Add(match1);
            DateTime date2 = new DateTime(2015, 12, 02, 20, 00, 00);
            Event match2 = new Event();
            match2.Code = 307;
            match2.Match = "Bastia vs Bordeaux";
            match2.Date = date2;
            events.CurrentOffer.Add(match2);
            DateTime date3 = new DateTime(2015, 12, 02, 21, 45, 00);
            Event match3 = new Event();
            match3.Code = 330;
            match3.Match = "Southampton vs Liverpool";
            match3.Date = date3;
            events.CurrentOffer.Add(match3);
            DateTime date4 = new DateTime(2015, 12, 02, 23, 00, 00);
            Event match4 = new Event();
            match4.Code = 341;
            match4.Match = "Cadiz vs Real Madrid";
            match4.Date = date4;
            events.CurrentOffer.Add(match4);
            events.CurrentOffer.Remove(match2);
            bool isFalse = events.CurrentOffer.Contains(match2);
            Assert.AreEqual(false, isFalse);
        }
        [TestMethod]
        public void ShouldRemoveMultipleEvents()
        {
            DateTime date = new DateTime(2015, 11, 28, 15, 00, 00);
            Event match1 = new Event();
            match1.Code = 3326;
            match1.Match = "U Cluj vs Medias";
            match1.Date = date;
            Events events = new Events();
            events.CurrentOffer.Add(match1);
            DateTime date2 = new DateTime(2015, 12, 02, 20, 00, 00);
            Event match2 = new Event();
            match2.Code = 307;
            match2.Match = "Bastia vs Bordeaux";
            match2.Date = date2;
            events.CurrentOffer.Add(match2);
            DateTime date3 = new DateTime(2015, 12, 02, 21, 45, 00);
            Event match3 = new Event();
            match3.Code = 330;
            match3.Match = "Southampton vs Liverpool";
            match3.Date = date3;
            events.CurrentOffer.Add(match3);
            DateTime date4 = new DateTime(2015, 12, 02, 23, 00, 00);
            Event match4 = new Event();
            match4.Code = 341;
            match4.Match = "Cadiz vs Real Madrid";
            match4.Date = date4;
            events.CurrentOffer.Add(match4);
            events.CurrentOffer.Remove(match2);
            bool isFalse = events.CurrentOffer.Contains(match2);
            Assert.AreEqual(false, isFalse);
            events.CurrentOffer.Remove(match1);
            int count = events.CurrentOffer.Count;
            Assert.AreEqual(2, count);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bookmaker;
using System.Collections.Generic;

namespace BettingTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void EmptyOffer()
        {
            Offer offer = new Offer();
            int numberOfEventsInOffer = offer.Events.Capacity;
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
            Offer offer = new Offer();
            if (date >= DateTime.Now)
                offer.Events.Add(match1);           

        }
        [TestMethod]
        public void AddMultipleEventsToTheCurrentOffer()
        {
            DateTime date = new DateTime(2015, 11, 28, 15, 00, 00);
            Event match1 = new Event();
            match1.Code = 3326;
            match1.Match = "U Cluj vs Medias";
            match1.Date = date;
            Offer offer = new Offer();
            offer.Events.Add(match1);
            DateTime date2 = new DateTime(2015, 12, 02, 20, 00, 00);
            Event match2 = new Event();
            match2.Code = 307;
            match2.Match = "Bastia vs Bordeaux";
            match2.Date = date2;
            offer.Events.Add(match2);
        }
        [TestMethod]
        public void ShouldNotRemoveIfCurrentOfferIsEmpty()
        {            
            DateTime date = new DateTime(2015, 12, 02, 21, 45, 00);
            Event match = new Event();
            match.Code = 330;
            match.Match = "Southampton vs Liverpool";
            match.Date = date;
            Offer offer = new Offer();
            offer.Events.Remove(match);
            int nr = offer.Events.Capacity;
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
            Offer offer = new Offer();
            offer.Events.Add(match1);
            DateTime date2 = new DateTime(2015, 12, 02, 20, 00, 00);
            Event match2 = new Event();
            match2.Code = 307;
            match2.Match = "Bastia vs Bordeaux";
            match2.Date = date2;
            offer.Events.Add(match2);
            DateTime date3 = new DateTime(2015, 12, 02, 21, 45, 00);
            Event match3 = new Event();
            match3.Code = 330;
            match3.Match = "Southampton vs Liverpool";
            match3.Date = date3;
            offer.Events.Add(match3);
            DateTime date4 = new DateTime(2015, 12, 02, 23, 00, 00);
            Event match4 = new Event();
            match4.Code = 341;
            match4.Match = "Cadiz vs Real Madrid";
            match4.Date = date4;
            offer.Events.Add(match4);
            offer.Events.Remove(match2);
            bool isFalse = offer.Events.Contains(match2);
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
            Offer offer = new Offer();
            offer.Events.Add(match1);
            DateTime date2 = new DateTime(2015, 12, 02, 20, 00, 00);
            Event match2 = new Event();
            match2.Code = 307;
            match2.Match = "Bastia vs Bordeaux";
            match2.Date = date2;
            offer.Events.Add(match2);
            DateTime date3 = new DateTime(2015, 12, 02, 21, 45, 00);
            Event match3 = new Event();
            match3.Code = 330;
            match3.Match = "Southampton vs Liverpool";
            match3.Date = date3;
            offer.Events.Add(match3);
            DateTime date4 = new DateTime(2015, 12, 02, 23, 00, 00);
            Event match4 = new Event();
            match4.Code = 341;
            match4.Match = "Cadiz vs Real Madrid";
            match4.Date = date4;
            offer.Events.Add(match4);
            offer.Events.Remove(match2);
            bool isFalse = offer.Events.Contains(match2);
            Assert.AreEqual(false, isFalse);
            offer.Events.Remove(match1);
            int count = offer.Events.Count;
            Assert.AreEqual(2, count);
        }
        [TestMethod]
        public void CalculateTotalOdds()
        {
            DateTime date = new DateTime(2015, 12, 04, 21, 30, 00);
            FootballMatch match1 = new FootballMatch();        
            match1.Code = 677;
            match1.Match = "Nice vs PSG";
            match1.Date = date;
            match1.MainBet = mainBet.awayWin;
            match1.OddsForGuests = 1.5;
            Ticket ticket = new Ticket();            
            ticket.events.Add(match1);
            DateTime date2 = new DateTime(2015, 12, 04, 21, 45, 00);
            FootballMatch match2 = new FootballMatch();
            match2.Code = 439;
            match2.Match = "Lazio vs Juventus";
            match2.Date = date2;
            match2.MainBet = mainBet.Draw;
            match2.OddsForDraw = 3.2;            
            ticket.events.Add(match2);
            double totalOdds = Math.Round( ticket.CalculateTotalOdds(), 1);
            double expected = 4.8;
            Assert.AreEqual(expected, totalOdds);
        }
        [TestMethod]
        public void CalculatePotentialWinning()
        {
            DateTime date = new DateTime(2015, 12, 04, 21, 30, 00);
            FootballMatch match1 = new FootballMatch();
            match1.Code = 677;
            match1.Match = "Nice vs PSG";
            match1.Date = date;
            match1.MainBet = mainBet.awayWin;
            match1.OddsForGuests = 1.5;
            Ticket ticket = new Ticket(10);
            ticket.events.Add(match1);
            DateTime date2 = new DateTime(2015, 12, 04, 21, 45, 00);
            FootballMatch match2 = new FootballMatch();
            match2.Code = 439;
            match2.Match = "Lazio vs Juventus";
            match2.Date = date2;
            match2.MainBet = mainBet.Draw;
            match2.OddsForDraw = 3.2;
            ticket.events.Add(match2);
            double totalOdds = Math.Round(ticket.CalculateTotalOdds(), 1);                        
            double actual = Math.Round(ticket.CalculateWinnings(), 1);
            Assert.AreEqual(48, actual);
        }
        [TestMethod]
        public void ShouldNotAcceptStakeLowerThanTheMinimum()
        {
           
        }
    }
}

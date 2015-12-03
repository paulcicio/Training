using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmaker
{
    public class User
    {
        private string user;
        private string password;
        private decimal balance;
        private Betting_History bettingHistory;
        private TransactionHistory depositHistory;
        private TransactionHistory withdrawHistory;
    }
    public class Event
    {
        private int code;
        private string match;
        private DateTime date;

        public int Code
        {
            get { return code; }
            set { code = value; }
        }
        public string Match
        {
            get { return match; }
            set { match = value; }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
    }
    public class Events
    {
        private List<Event> currentOffer = new List<Event>();
        public List<Event> CurrentOffer
        {
            get { return currentOffer; }
            set { currentOffer = value; }
        }
    }
    public class FootballMatch : Event
    {
        private bool betOnHosts;
        private bool betOnDraw;
        private bool betOnGuests;
        private decimal oddsForHosts;
        private decimal oddsForDraw;
        private decimal oddsForGuests;
        private SpecialBets specialBet;
    }
    public class SpecialBets
    {
        private bool firstHalf;
        private bool handicap;
        private bool bothTeamsToScore;
        private bool totalGoals;
        private bool halfTime_fullTime;
        private bool correctScore;
    }
    public class Betting_History
    {
        Dictionary<uint, Ticket> tickets = new Dictionary<uint, Ticket>();
        private DateTime date;
        private bool isWon;
        private decimal stake;
        private decimal odds;
        private decimal winnings;
    }
    public class Ticket
    {
        private List<Event> events;
        private decimal stake;
        private decimal totalOdds;
        private decimal estimatedWin;
    }
    public class TransactionHistory
    {
        private DateTime date;
        private uint transactionID;
        private string transactionType;
        private decimal ammount;
        private decimal totalSold;
    }
}

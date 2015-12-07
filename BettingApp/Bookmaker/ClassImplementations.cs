using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmaker
{
    public enum mainBet { homeWin, Draw, awayWin };    

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
        private mainBet mainBet;
        private double oddsForHosts;
        private double oddsForDraw;
        private double oddsForGuests;
        private SpecialBets specialBet;

        public mainBet MainBet
        {
            get { return mainBet; }
            set { mainBet = value; }
        }

        public double OddsForHosts
        {
            get { return oddsForHosts; }
            set { oddsForHosts = value; }
        }
        public double OddsForDraw
        {
            get { return oddsForDraw; }
            set { oddsForDraw = value; }
        }
        public double OddsForGuests
        {
            get { return oddsForGuests; }
            set { oddsForGuests = value; }
        }
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
        private double stake;
        private double odds;
        private double winnings;
    }
    public class Ticket : IEnumerable
    {
        public List<Event> events = new List<Event>();
        private double stake;
        private double totalOdds = 1;
        private double estimatedWin;
        private int idTicket;

        public double Stake
        {
            get { return stake; }
            set { stake = value; }
        }

        int position = -1;

        public object Current
        {
            get
            {
                return Current;
            }
        }      

        public bool MoveNext()
        {
            position++;
            return (position < events.Count);
        }

        public void Reset()
        {
            position = -1;
        }       

        public IEnumerator<Event> GetEnumerator()
        {
            return events.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public double CalculateTotalOdds()
        {

            mainBet selection;
            foreach (FootballMatch match in this.events)
            {
                selection = match.MainBet;
                switch (selection)
                {
                    case mainBet.homeWin: totalOdds *= match.OddsForHosts;
                        break;
                    case mainBet.awayWin: totalOdds *= match.OddsForGuests;
                        break;
                    case mainBet.Draw: totalOdds *= match.OddsForDraw;
                        break;
                }
            }
            return totalOdds;
        }
        public double CalculateWinnings()
        {
            return stake * totalOdds;
        }
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

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
        private Transaction_History depositHistory;
        private Transaction_History withdrawHistory;
    }
    public class Event
    {
        private int code;
        private string match;
        private DateTime date;
    }
    public class Football_Match : Event
    {
        private bool betOnHosts;
        private bool betOnDraw;
        private bool betOnGuests;
        private decimal oddsForHosts;
        private decimal oddsForDraw;
        private decimal oddsForGuests;
        private Special_Bets specialBet;
    }
    public class Special_Bets
    {
        private bool firstHalf;
        private bool handicap;
        private bool bothTeamsToScore;
        private bool TotalGoals;
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
    public class Transaction_History
    {
        private DateTime date;
        private uint transactionID;
        private string transactionType;
        private decimal ammount;
        private decimal totalSold;
    }
}

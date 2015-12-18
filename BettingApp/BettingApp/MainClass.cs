using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookmaker;
using Should;

namespace BettingApp
{
    class MainClass
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\PaulCicio\Documents\Visual Studio 2015\Projects\Training\BettingApp\BettingApp\bin\Debug\CurrentOffer.txt";
            string path2 = @"C:\Users\PaulCicio\Documents\Visual Studio 2015\Projects\Training\BettingApp\BettingApp\bin\Debug\Odds.txt";
            if (args.Count() == 0)
            {
                Console.WriteLine("Hint: First argument should be Add, Remove or New");
                return;
            }
            string choice = args[0];
            Offer offer = new Offer();
            if (!System.IO.File.Exists(path)) 
                System.IO.File.Create(path);
            if (System.IO.File.Exists(path2))
            {
                System.IO.File.Delete(path2);
                System.IO.File.Create(path2).Close();
            }
            
            string[] readLines = System.IO.File.ReadAllLines(path);
            for(int i=0; i < readLines.Length; i+=3)
            {
                FootballMatch currentEvent = new FootballMatch();
                currentEvent.Code = int.Parse(readLines[i]);
                currentEvent.Match = readLines[i+1];
                string date = readLines[i + 2];                
                string format = "MM/dd/yyyy HH:mm:ss";
                IFormatProvider culture = System.Threading.Thread.CurrentThread.CurrentCulture;
                DateTime dt2 = DateTime.ParseExact(date, format, culture, System.Globalization.DateTimeStyles.AssumeLocal);
                currentEvent.Date = new DateTime(dt2.Year, dt2.Month, dt2.Day, dt2.Hour, dt2.Minute, dt2.Second);
                offer.Events.Add(currentEvent);
            }
            string[] readLines2 = System.IO.File.ReadAllLines(path);
            for (int i = 0; i < readLines2.Length; i += 3)
            {
                FootballMatch currentEvent = new FootballMatch();
                currentEvent.Code = int.Parse(readLines2[i]);
                
            }
            switch (choice)
            {
                case "?": Console.WriteLine("Syntax example: Add 300 \"Milan vs Inter\" 12/03/2015 21:00:00 1.65 3.6 5.55, Remove 300, New 300 X 10");
                    break;
                case "Add": Console.WriteLine("Enter the event's details: code, match, date and the odds for 1, X, 2");
                    if (args.Length != 7)
                    {
                        Console.WriteLine("Syntax error! Check the help for examples");
                        break;
                    }
                    FootballMatch match1 = new FootballMatch();                    
                    match1.Code = int.Parse(args[1]);
                    match1.Match = args[2];
                    string date = args[3];
                    match1.OddsForHosts = double.Parse(args[4]);
                    match1.OddsForDraw = double.Parse(args[5]);
                    match1.OddsForGuests = double.Parse(args[6]);
                    string format = "MM/dd/yyyy HH:mm:ss";
                    IFormatProvider culture = System.Threading.Thread.CurrentThread.CurrentCulture;
                    DateTime dt2 = DateTime.ParseExact(date, format, culture, System.Globalization.DateTimeStyles.AssumeLocal);
                    match1.Date = new DateTime(dt2.Year, dt2.Month, dt2.Day, dt2.Hour, dt2.Minute, dt2.Second);

                    if (match1.Date < DateTime.Now)
                    {
                        Console.WriteLine("Event already started");                        
                    }
                    else
                    {                        
                        if (!offer.Events.Contains(match1))
                            offer.Events.Add(match1);
                        Console.WriteLine("Event added to the current offer!");
                        string[] lines = { match1.Code.ToString(), match1.Match, match1.Date.ToString("MM/dd/yyyy HH:mm:ss") };
                        System.IO.File.AppendAllLines(path, lines);
                        string[] lines2 = { match1.Code.ToString(), "1 " + match1.OddsForHosts.ToString(), "X " + match1.OddsForDraw.ToString(), "2 " + match1.OddsForGuests.ToString() };
                        System.IO.File.AppendAllLines(path2, lines2);
                    }
                    foreach (var current in offer.Events)
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("Match code: " + current.Code);
                        Console.WriteLine(current.Match);
                        Console.WriteLine("Event takes place on: " + current.Date);                                              
                    }                                        
                    break;                    
                case "Remove": Console.WriteLine("Enter the code of the match you want to be removed from the offer");
                    if (args.Length != 2)
                    {
                        Console.WriteLine("Syntax error! Check the help for examples");
                        break;
                    }
                    Event match = new Event();
                    match.Code = int.Parse(args[1]);

                    foreach (var value in offer.Events)
                        if (match.Code == value.Code)
                        {
                            offer.Events.Remove(value);
                            break;
                        }
                    Console.WriteLine("Event removed from the current offer!");
                    System.IO.File.Delete(path);
                    foreach (var current in offer.Events)
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("Match code: " + current.Code);
                        Console.WriteLine(current.Match);
                        Console.WriteLine("Event takes place on: " + current.Date);
                        string[] line = { current.Code.ToString(), current.Match, current.Date.ToString() };
                        System.IO.File.AppendAllLines(path, line);
                    }
                    break;
                case "New": Console.WriteLine("Place your bets please. Enter the match's code, the selection and the stake");
                    if (args.Length <= 3)
                    {
                        Console.WriteLine("Syntax error! Check the help for examples");
                        break;
                    }
                    for (int i = 0; i < readLines2.Length; i+=4)
                    {
                        Console.WriteLine("Code: " + readLines2[i]);
                        Console.WriteLine(readLines2[i + 1]);
                        Console.WriteLine(readLines2[i + 2]);
                        Console.WriteLine(readLines2[i + 3]);
                    }
                    FootballMatch event1 = new FootballMatch();
                    event1.Code = int.Parse(args[1]);
                    event1.MainBet = (mainBet) int.Parse(args[2]);
                    Ticket ticket = new Ticket(100);                                    
                    ticket.events.Add(event1);
                    Console.WriteLine(event1.Code);
                    Console.WriteLine(event1.Match);
                    Console.WriteLine(event1.MainBet);
                    Console.WriteLine(ticket.GetStake());
                    double totalOdds = ticket.CalculateTotalOdds();
                    Console.WriteLine(totalOdds);
                    double winnings = ticket.CalculateWinnings();
                    Console.WriteLine(winnings);
                    break;               
                default: Console.WriteLine("Hint: First argument should be Add or Remove");
                    break;
            }
        }
    }
}

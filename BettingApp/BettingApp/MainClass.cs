using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookmaker;

namespace BettingApp
{
    class MainClass
    {
        static void Main(string[] args)
        {
            if (args.Count() == 0)
            {
                Console.WriteLine("Hint: First argument should be Add or Remove");
                return;
            }
            string choice = args[0];
            switch (choice)
            {
                case "?": Console.WriteLine("Syntax example: Add 300 \"Milan vs Inter\" 2015/12/03/21/00/00");
                    break;
                case "Add": Console.WriteLine("Event added to the current offer!");
                    if (args.Length != 4)
                    {
                        Console.WriteLine("Syntax error! Check the help for examples");
                        break;
                    }
                    Event match1 = new Event();                    
                    match1.Code = int.Parse(args[1]);
                    match1.Match = args[2];
                    string date = args[3];
                    string[] dt = date.Split('/');
                    match1.Date = new DateTime(int.Parse(dt[0]), int.Parse(dt[1]), int.Parse(dt[2]), int.Parse(dt[3]), int.Parse(dt[4]), int.Parse(dt[5]));
                    Events offer = new Events();
                    if (match1.Date >= DateTime.Now)
                        offer.CurrentOffer.Add(match1);
                    break;
                case "Remove": Console.WriteLine("Event removed from the current offer!");
                    if (args.Length != 4)
                    {
                        Console.WriteLine("Syntax error! Check the help for examples");
                        break;
                    }
                    Event match = new Event();
                    match.Code = int.Parse(args[1]);
                    match.Match = args[2];
                    string dateTime = args[3];
                    string[] time = dateTime.Split('/');
                    match.Date = new DateTime(int.Parse(time[0]), int.Parse(time[1]), int.Parse(time[2]), int.Parse(time[3]), int.Parse(time[4]), int.Parse(time[5]));
                    Events events = new Events();
                    events.CurrentOffer.Add(match);
                    if (match.Date < DateTime.Now)
                        events.CurrentOffer.Remove(match);
                    foreach (var value in events.CurrentOffer)
                        if (match.Code == value.Code)
                            events.CurrentOffer.Remove(match);
                    break;
                default: Console.WriteLine("Hint: First argument should be Add or Remove");
                    break;
            }
        }
    }
}

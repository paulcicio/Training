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
            string path = @"C:\Users\PaulCicio\Documents\Visual Studio 2015\Projects\Training\BettingApp\BettingApp\bin\Debug\CurrentOffer.txt";
            if (args.Count() == 0)
            {
                Console.WriteLine("Hint: First argument should be Add or Remove");
                return;
            }
            string choice = args[0];
            Events offer = new Events();
            if (!System.IO.File.Exists(path)) 
                System.IO.File.Create(path);           
            string[] readLines = System.IO.File.ReadAllLines(path);
            for(int i=0; i < readLines.Length; i+=3)
            {
                Event currentEvent = new Event();
                currentEvent.Code = int.Parse(readLines[i]);
                currentEvent.Match = readLines[i+1];
                currentEvent.Date = DateTime.Parse((readLines[i+2]));
                offer.CurrentOffer.Add(currentEvent); 
            }
            switch (choice)
            {
                case "?": Console.WriteLine("Syntax example: Add 300 \"Milan vs Inter\" 2015/12/03/21/00/00");
                    break;
                case "Add": Console.WriteLine("Enter the event's details: code, match and date");
                    if (args.Length != 4)
                    {
                        Console.WriteLine("Syntax error! Check the help for examples");
                        break;
                    }
                    Event match1 = new Event();                    
                    match1.Code = int.Parse(args[1]);
                    match1.Match = args[2];
                    string date = args[3];
                    string format = "MM/dd/yyyy HH:mm:ss";
                    IFormatProvider culture = System.Threading.Thread.CurrentThread.CurrentCulture;
                    DateTime dt2 = DateTime.ParseExact(date, format, culture, System.Globalization.DateTimeStyles.AssumeLocal);
                    match1.Date = new DateTime(dt2.Year, dt2.Month, dt2.Day, dt2.Hour, dt2.Minute, dt2.Second);                                       

                    if (match1.Date >= DateTime.Now)
                        offer.CurrentOffer.Add(match1);
                    Console.WriteLine("Event added to the current offer!");
                    string[] lines = { match1.Code.ToString(), match1.Match, match1.Date.ToString() };
                    System.IO.File.AppendAllLines(path, lines);
                    foreach (var current in offer.CurrentOffer)
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
                    
                    foreach (var value in offer.CurrentOffer)
                        if (match.Code == value.Code)
                            offer.CurrentOffer.Remove(value);
                    Console.WriteLine("Event removed from the current offer!");
                    System.IO.File.Delete(path);
                    foreach (var current in offer.CurrentOffer)
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("Match code: " + current.Code);
                        Console.WriteLine(current.Match);
                        Console.WriteLine("Event takes place on: " + current.Date);
                        string[] line = { current.Code.ToString(), current.Match, current.Date.ToString() };
                        System.IO.File.AppendAllLines(path, line);
                    }
                    break;
                default: Console.WriteLine("Hint: First argument should be Add or Remove");
                    break;
            }
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Football
{
    [TestClass]
    public class UnitTest1
    {
        public Match[] round = { new Match("U Cluj", "CFR", 2, 1), new Match("Petrolul", "Steaua", 0, 0), new Match("Botosani", "CSU", 3, 2), new Match("Dinamo", "ASA", 2, 1), new Match("Chiajna", "Astra", 0, 2) };

        [TestMethod]
        public void TotalGoals()
        {
            Assert.AreEqual(13, CalculateTotalNumberOfGoals(round));
        }

        [TestMethod]
        public void AverageGoals()
        {
            Assert.AreEqual(2.6, CalculateAverageNumberOfGoals(round));
        }

        [TestMethod]
        public void LastMatch()
        {
            Match lastMatch = new Match("U", "Brasov", 0, 0);
            Match[] expectedValue = { new Match("U Cluj", "CFR", 2, 1), new Match("Petrolul", "Steaua", 0, 0), new Match("Botosani", "CSU", 3, 2), new Match("Dinamo", "ASA", 2, 1), new Match("Chiajna", "Astra", 0, 2), lastMatch };
            CollectionAssert.AreEqual(expectedValue, AddLastMatchOfTheRound(round, lastMatch));
        }

        [TestMethod]
        public void BestGoalsDifference()
        {
            Assert.AreEqual(2, CalculateBestGoalDifference(round));
        }

        public struct Match
        {
            public string hosts;
            public string guests;
            public int homeTeamGoals;
            public int awayTeamGoals;
            public Match(string hosts, string guests, int homeTeamGoals, int awayTeamGoals)
            {
                this.hosts = hosts;
                this.guests = guests;
                this.homeTeamGoals = homeTeamGoals;
                this.awayTeamGoals = awayTeamGoals;
            }
        }
        public static Match[] AddLastMatchOfTheRound(Match[] round, Match lastMatch)
        {
            Array.Resize(ref round, round.Length + 1);
            round[round.Length - 1] = lastMatch;
            return round;
        }
        public static int CalculateTotalNumberOfGoals(Match[] round)
        {
            int totalGoals = 0;
            for (int i = 0; i < round.Length; i++)
            {
                totalGoals += round[i].homeTeamGoals + round[i].awayTeamGoals;
            }
            return totalGoals;
        }
        public static double CalculateAverageNumberOfGoals(Match[] round)
        {
            return (double)CalculateTotalNumberOfGoals(round) / round.Length;
        }

        private static int MaxValue(int x, int y)
        {
            if (x >= y)
                return x;
            else return y;
        }

        public static int CalculateBestGoalDifference(Match[] round)
        {
            int bestGoalsDifference = 0;
            int[] goalDifference = new int[round.Length];

            for (int i = 0; i < round.Length; i++)
            {
                goalDifference[i] = Math.Abs(round[i].homeTeamGoals - round[i].awayTeamGoals);
            }
            for (int i = 0; i < round.Length; i++)
                bestGoalsDifference = MaxValue(goalDifference[i], bestGoalsDifference);
            return bestGoalsDifference;
        }

    }
}

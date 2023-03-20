using System.Diagnostics;

using Laba1.Console.Variant;

namespace Laba1.Console;

class Program
{
    static void Main()
    {
        //1
        ResearchTeam team = new("IT", "Team1", 11111, TimeFrame.TwoYears, Array.Empty<Paper>());
        System.Console.WriteLine(team.ToShortString());

		//2
		System.Console.WriteLine($"{team[TimeFrame.Year]}\n" +
                          $"{team[TimeFrame.TwoYears]}\n" +
                          $"{team[TimeFrame.Long]}");

        //3
        team.ResearchTopic = "Topic";
        team.ResearchOrganization = "Organization";
        team.RegistrationNumber = 111;
        team.ResearchDuration = TimeFrame.Long;
        team.AddPapers(new Paper("Title 3", new Person("First 3", "Last 3", 
            new DateTime(2000, 1, 1)), new DateTime(2000, 1, 1)));

		System.Console.WriteLine(team.ToString());

        //4
        team.AddPapers(new Paper("Title 2", new Person("First 2", "Last 2", new DateTime(2000, 1, 1)), new DateTime(2000, 1, 1)),
                       new Paper("Title 3", new Person("First 3", "Last 3", new DateTime(2000, 1, 1)), new DateTime(2000, 1, 1)));

		System.Console.WriteLine(team.ToString());

		//5
		System.Console.WriteLine(team.LatestPublication);

        //6
        // Операция содномерным массивом
        int n = 1000000;
        Paper[] papers1 = new Paper[n];
        Stopwatch stopwatch1 = new();
        stopwatch1.Start();
        for(int i = 0; i < n; i++)
        {
            papers1[i] = new Paper($"Title {i}", new Person($"First {i}", $"Last {i}", new DateTime(2000, 1, 1)), new DateTime(2000, 1, 1));
        }
        stopwatch1.Stop();
		System.Console.WriteLine($"Одномерный массив: {stopwatch1.ElapsedMilliseconds} ms");

        // Операция с двумерным прямоугольным массивом Paper
        int rows = 1000;
        int cols = 1000;
        Paper[,] papers2 = new Paper[rows, cols];
        Stopwatch stopwatch2 = new();
        stopwatch2.Start();
		for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < cols; j++)
            {
                papers2[i, j] = new Paper($"Title {i} {j}", new Person($"First {i} {j}", $"Last {i} {j}", new DateTime(2000, 1, 1)), new DateTime(2000, 1, 1));
            }
        }
        stopwatch2.Stop();
        System.Console.WriteLine($"Двумерный прямоугольный массив: {stopwatch2.ElapsedMilliseconds} ms");

		// Операция с двумерным ступенчатым массивом Paper
		Paper[][] papers3 = new Paper[rows][];
        for(int i = 0; i < rows; i++)
        {
            papers3[i] = new Paper[cols];
        }
        Stopwatch stopwatch3 = new();
        stopwatch3.Start();
        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < cols; j++)
            {
                papers3[i][j] = new Paper($"Title {i} {j}", new Person($"First {i} {j}", $"Last {i} {j}", new DateTime(2000, 1, 1)), new DateTime(2000, 1, 1));
            }
        }
        stopwatch3.Stop();
        System.Console.WriteLine($"Двумерный ступенчатый массив: {stopwatch3.ElapsedMilliseconds} ms");
    }
}

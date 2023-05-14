using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba4;

public class TestCollections
{

    private List<Team> _teams;
    private List<string> _teamNames;
    private Dictionary<Team, ResearchTeam> _teamResearch;
    private Dictionary<string, ResearchTeam> _teamNameResearch;

    public TestCollections(int count)
    {
        _teams = new List<Team>();
        _teamNames = new List<string>();
        _teamResearch = new Dictionary<Team, ResearchTeam>();
        _teamNameResearch = new Dictionary<string, ResearchTeam>();

        for (int i = 0; i < count; i++)
        {
            var team = GenerateResearchTeam(i);
            _teams.Add(team.ResearchTeamInfo);
            _teamNames.Add(team.ResearchTopic);
            _teamResearch[team.ResearchTeamInfo] = team;
            _teamNameResearch[team.ResearchTopic] = team;
        }
    }
   


    public static ResearchTeam GenerateResearchTeam(int index)
    {
        return new ResearchTeam("Organization" + index, index, "ResearchTopic" + index, TimeFrame.Year);
    }

    public void Search(Team team, string name)
    {
        var stopwatch = new Stopwatch();

        stopwatch.Start();
        bool containsTeam = _teams.Contains(team);
        stopwatch.Stop();
        Console.WriteLine($"Search in List<Team> took {stopwatch.ElapsedMilliseconds} ms");

        stopwatch.Restart();
        bool containsName = _teamNames.Contains(name);
        stopwatch.Stop();
        Console.WriteLine($"Search in List<string> took {stopwatch.ElapsedMilliseconds} ms");

        stopwatch.Restart();
        bool containsTeamInDictionary = _teamResearch.ContainsKey(team);
        stopwatch.Stop();
        Console.WriteLine($"Search in Dictionary<Team, ResearchTeam> by key took {stopwatch.ElapsedMilliseconds} ms");

        stopwatch.Restart();
        bool containsNameInDictionary = _teamNameResearch.ContainsKey(name);
        stopwatch.Stop();
        Console.WriteLine($"Search in Dictionary<string, ResearchTeam> by key took {stopwatch.ElapsedMilliseconds} ms");

        stopwatch.Restart();
        var researchTeamFromTeam = _teamResearch[team];
        stopwatch.Stop();
        Console.WriteLine($"Search in Dictionary<Team, ResearchTeam> by value took {stopwatch.ElapsedMilliseconds} ms");

        stopwatch.Restart();
        var researchTeamFromName = _teamNameResearch[name];
        stopwatch.Stop();
        Console.WriteLine($"Search in Dictionary<string, ResearchTeam> by value took {stopwatch.ElapsedMilliseconds} ms");
    }

    public void MeasureTimeForFirstElement()
    {
        if (_teams.Count > 0)
        {
            var team = _teams.First();
            var name = _teamNames.First();
            Search(team, name);
        }
    }

    public void MeasureTimeForMiddleElement()
    {
        if (_teams.Count > 0)
        {
            var team = _teams[_teams.Count / 2];
            var name = _teamNames[_teamNames.Count / 2];
            Search(team, name);
        }
    }

    public void MeasureTimeForLastElement()
    {
        if (_teams.Count > 0)
        {
            var team = _teams.Last();
            var name = _teamNames.Last();
            Search(team, name);
        }
    }

    public void MeasureTimeForNonexistentElement()
    {
        var team = new Team("Nonexistent", -1);
        var name = "Nonexistent";
        Search(team, name);
    }

}

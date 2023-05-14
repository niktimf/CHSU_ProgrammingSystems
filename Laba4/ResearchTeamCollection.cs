using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba4;


public class ResearchTeamCollection
{

    private List<ResearchTeam> _teams;

    public string CollectionName { get; set; }

    public ResearchTeamCollection()
    {
        _teams = new List<ResearchTeam>();
    }

    public override string ToString()
    {
        return string.Join("\n", _teams);
    }

    public string ToShortString()
    {
        return string.Join("\n", _teams.Select(t => t.ToShortString()));
    }

    public void SortByRegistrationNumber()
    {
        _teams.Sort();
    }

    public void SortByResearchTopic()
    {
        _teams.Sort((x, y) => x.ResearchTopic.CompareTo(y.ResearchTopic));
    }

    public void SortByPublicationCount()
    {
        _teams.Sort((x, y) => x.Publications.Count.CompareTo(y.Publications.Count));
    }



    public delegate void TeamListHandler(object source, TeamListHandlerEventArgs args);
    public event TeamListHandler ResearchTeamAdded;
    public event TeamListHandler ResearchTeamInserted;

    public void AddDefaults()
    {
        var team = new ResearchTeam();
        _teams.Add(team);
        ResearchTeamAdded?.Invoke(this, new TeamListHandlerEventArgs(CollectionName, "Added", _teams.Count - 1));
    }

    public void AddResearchTeams(params ResearchTeam[] teams)
    {
        foreach (var team in teams)
        {
            _teams.Add(team);
            ResearchTeamAdded?.Invoke(this, new TeamListHandlerEventArgs(CollectionName, "Added", _teams.Count - 1));
        }
    }

    public void InsertAt(int j, ResearchTeam rt)
    {
        if (j < _teams.Count)
        {
            _teams.Insert(j, rt);
            ResearchTeamInserted?.Invoke(this, new TeamListHandlerEventArgs(CollectionName, "Inserted", j));
        }
        else
        {
            _teams.Add(rt);
            ResearchTeamAdded?.Invoke(this, new TeamListHandlerEventArgs(CollectionName, "Added", _teams.Count - 1));
        }
    }

    public ResearchTeam this[int index]
    {
        get => (index >= 0 && index < _teams.Count) ? _teams[index] : null;
        set
        {
            if (index >= 0 && index < _teams.Count)
            {
                _teams[index] = value;
            }
            else if (index == _teams.Count)
            {
                AddResearchTeams(value);
            }
        }
    }

    public class TeamsJournalEntry
    {
        public string CollectionName { get; set; }
        public string EventName { get; set; }
        public int NewElementIndex { get; set; }

        public TeamsJournalEntry(string collectionName, string eventName, int newElementIndex)
        {
            CollectionName = collectionName;
            EventName = eventName;
            NewElementIndex = newElementIndex;
        }

        public override string ToString()
        {
            return $"Collection Name: {CollectionName}, Event: {EventName}, New Element Index: {NewElementIndex}";
        }
    }

    public class TeamsJournal
    {
        private List<TeamsJournalEntry> _journal;

        public TeamsJournal()
        {
            _journal = new List<TeamsJournalEntry>();
        }

        public void ResearchTeamAddedOrInsertedHandler(object source, TeamListHandlerEventArgs args)
        {
            _journal.Add(new TeamsJournalEntry(args.CollectionName, args.ChangeType, args.ElementIndex));
        }

        public override string ToString()
        {
            return string.Join("\n", _journal);
        }


    }



    public int MinRegistrationNumber
        {
            get
            {
                if (_teams.Count == 0)
                    return -1;

                return _teams.Min(t => t.RegistrationNumber);
            }
        }

        public IEnumerable<ResearchTeam> TwoYearResearch
        {
            get
            {
                return _teams.Where(t => t.ResearchDuration == TimeFrame.TwoYears);
            }

    
        }

        public List<ResearchTeam> NGroup(int value)
        {
            return _teams.Where(t => t.Participants.Count == value).ToList();
        }



    public IEnumerable<ResearchTeam> ResearchTeamsGroupByTime(TimeFrame timeFrame)
    {
        return _teams.Where(t => t.ResearchDuration == timeFrame);
    }

    public IEnumerable<IGrouping<int, ResearchTeam>> GroupByPublicationsQuantity()
    {
    return _teams.GroupBy(t => t.Publications.Count);
    }
}



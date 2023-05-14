using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3;


public class ResearchTeamCollection
{
        private List<ResearchTeam> _teams;

        public ResearchTeamCollection()
        {
            _teams = new List<ResearchTeam>();
        }

        public void AddDefaults()
        {
            _teams.Add(new ResearchTeam());
        }

        public void AddResearchTeams(params ResearchTeam[] teams)
        {
            _teams.AddRange(teams);
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



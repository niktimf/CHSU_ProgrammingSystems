using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3;
public class ResearchTeam : Team, INameAndCopy, IEnumerable
{
    private string _researchTopic;
    private TimeFrame _researchDuration;
    private ArrayList _participants;
    private ArrayList _publications;

    public ResearchTeam() : base()
    {
        _researchTopic = "Исследование";
        _researchDuration = TimeFrame.Year;
        _participants = new ArrayList();
        _publications = new ArrayList();
    }

    public ResearchTeam(string organization, int registrationNumber, string researchTopic, TimeFrame researchDuration)
    : base(organization, registrationNumber)
    {
        _researchTopic = researchTopic;
        _researchDuration = researchDuration;
        _participants = new ArrayList();
        _publications = new ArrayList();
    }

    public string ResearchTopic
    {
        get => _researchTopic;
        set => _researchTopic = value;
    }

    public TimeFrame ResearchDuration
    {
        get => _researchDuration;
        set => _researchDuration = value;
    }

    public ArrayList Publications
    {
        get => _publications;
        set => _publications = value;
    }

    public Paper LatestPublication
    {
        get
        {
            if (_publications.Count == 0)
            {
                return null;
            }
            Paper latest = (Paper)_publications[0];
            foreach (Paper p in _publications)
            {
                if (p.PublicationTime > latest.PublicationTime)
                {
                    latest = p;
                }
            }
            return latest;
        }
    }

    public void AddPapers(params Paper[] papers)
    {
        _publications.AddRange(papers);
    }

    public override string ToString()
    {
        return base.ToString() +
        $"\nResearch Topic: {_researchTopic}" +
        $"\nResearch Duration: {_researchDuration}" +
        $"\nParticipants: {string.Join(", ", _participants)}" +
        $"\nPublications: {string.Join(", ", _publications)}";
    }

    public string ToShortString()
    {
        return base.ToString() +
        $"\nResearch Topic: {_researchTopic}" +
        $"\nResearch Duration: {_researchDuration}";
    }

    public override object DeepCopy()
    {
        ResearchTeam copy = (ResearchTeam)MemberwiseClone();
        copy._participants = new ArrayList(_participants);
        copy._publications = new ArrayList(_publications);
        return copy;
    }

    public ArrayList Participants
    {
        get => _participants;
        set => _participants = value;
    }

    public void AddMembers(params Person[] persons)
    {
        _participants.AddRange(persons);
    }

    public Team ResearchTeamInfo
    {
        get => new Team(Organization, RegistrationNumber);
        set
        {
            Organization = value.Organization;
            RegistrationNumber = value.RegistrationNumber;
        }
    }

    public IEnumerable<Person> MembersWithoutPublications
    {
        get
        {
            foreach (Person participant in _participants)
            {
                bool hasPublication = false;
                foreach (Paper publication in _publications)
                {
                    if (publication.PublicationAuthor.Equals(participant))
                    {
                        hasPublication = true;
                        break;
                    }
                }
                if (!hasPublication)
                {
                    yield return participant;
                }
            }
        }
    }

    public IEnumerable<Paper> GetPublicationsFromLastYears(int years)
    {
        DateTime currentDate = DateTime.Now;
        foreach (Paper paper in _publications)
        {
            if (currentDate - paper.PublicationTime <= TimeSpan.FromDays(365 * years))
            {
                yield return paper;
            }
        }
    }

    public IEnumerator GetEnumerator()
    {
        return new ResearchTeamEnumerator(this);
    }

    private class ResearchTeamEnumerator : IEnumerator
    {
        private ResearchTeam _researchTeam;
        private int _currentIndex;

        public ResearchTeamEnumerator(ResearchTeam researchTeam)
        {
            _researchTeam = researchTeam;
            _currentIndex = -1;
        }

        public bool MoveNext()
        {
            while (++_currentIndex < _researchTeam._participants.Count)
            {
                Person person = (Person)_researchTeam._participants[_currentIndex];
                if (_researchTeam._publications.Cast<Paper>().Any(p => p.PublicationAuthor.Equals(person)))
                {
                    return true;
                }
            }
            return false;
        }

        public void Reset()
        {
            _currentIndex = -1;
        }

        public object Current => _researchTeam._participants[_currentIndex];
    }


    public IEnumerable<Person> MembersWithMoreThanOnePublication()
    {
        foreach (Person person in _participants)
        {
            int publicationsCount = _publications.Cast<Paper>().Count(p => p.PublicationAuthor.Equals(person));
            if (publicationsCount > 1)
            {
                yield return person;
            }
        }
    }
    public IEnumerable<Paper> PublicationsLastYear()
    {
        DateTime oneYearAgo = DateTime.Now.AddYears(-1);
        foreach (Paper publication in _publications)
        {
            if (publication.PublicationTime > oneYearAgo)
            {
                yield return publication;
            }
        }
    }




}



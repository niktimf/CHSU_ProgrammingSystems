using System.Collections;
using System.Text;

namespace Laba2.Console;

/// <summary>Класс, содержащий информацию о команде исследований.</summary>
public class ResearchTeam : Team, INameAndCopy
{
    private string _researchTopic;
    private TimeFrame _duration;
    private ArrayList _members;
    private ArrayList _publications;

    // Конструкторы

    public ResearchTeam(string organization, string project, int registrationNumber, TimeFrame duration)
        : base(organization, project, registrationNumber)
    {
        _researchTopic = "Unknown";
        _duration = duration;
        _members = new ArrayList();
        _publications = new ArrayList();
    }

    public ResearchTeam() : this("Unknown Organization", "Unknown Project", 0, new TimeFrame())
    {
    }

    // Свойства

    public ArrayList Publications
    {
        get => _publications;
    }

    public Paper LatestPublication
    {
        get
        {
            Paper latest = null;
            foreach (Paper publication in _publications)
            {
                if (latest == null || publication.PublicationDate > latest.PublicationDate)
                {
                    latest = publication;
                }
            }
            return latest;
        }
    }

    public ArrayList Members
    {
        get => _members;
    }

    public override Team TeamData
    {
        get => base.TeamData;
        set => base.TeamData = value;
    }

    // Методы

    public void AddPapers(params Paper[] papers)
    {
        foreach (Paper paper in papers)
        {
            _publications.Add(paper);
        }
    }

    public void AddMembers(params Person[] members)
    {
        foreach (Person member in members)
        {
            _members.Add(member);
        }
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine(base.ToString());
        stringBuilder.AppendLine($"Research topic: {_researchTopic}");
        stringBuilder.AppendLine($"Duration: {_duration}");
        stringBuilder.AppendLine("Members:");
        foreach (Person member in _members)
        {
            stringBuilder.AppendLine(member.ToString());
        }
        stringBuilder.AppendLine("Publications:");
        foreach (Paper publication in _publications)
        {
            stringBuilder.AppendLine(publication.ToString());
        }
        return stringBuilder.ToString();
    }

    public string ToShortString()
    {
        return base.ToString() + $", Research topic: {_researchTopic}, Duration: {_duration}";
    }

    public object DeepCopy()
    {
        ResearchTeam copy = (ResearchTeam)MemberwiseClone();
        copy._members = new ArrayList();
        foreach (Person member in _members)
        {
            copy._members.Add(member.DeepCopy());
        }
        copy._publications = (ArrayList)_publications.Clone();
        return copy;
    }

    // Реализация интерфейса INameAndCopy

    public string Name
    {
        get => _researchTopic;
        set => _researchTopic = value;
    }

    public object GetCopy()
    {
        return DeepCopy();
    }
}




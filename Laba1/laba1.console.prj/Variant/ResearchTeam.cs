namespace Laba1.Console.Variant;

/// <summary>Класс, содержащий информацию о команде исследований.</summary>
public class ResearchTeam
{
	private string _researchTopic;
	private string _researchOrganization;
	private int _registrationNumber;
	private TimeFrame _researchDuration;
	private Paper[] _publicationList = Array.Empty<Paper>();


	public string ResearchTopic
	{
		get => _researchTopic;
		set => _researchTopic = value;
	}

	public string ResearchOrganization
	{
		get => _researchOrganization;
		set => _researchOrganization = value;
	}

	public int RegistrationNumber
	{
		get => _registrationNumber;
		set => _registrationNumber = value;
	}

	public TimeFrame ResearchDuration
	{
		get => _researchDuration;
		set => _researchDuration = value;
	}

	public Paper[] PublicationList
	{
		get => _publicationList;
		set => _publicationList = value;
	}

	public Paper? LatestPublication
	{
		get
		{
			if(PublicationList == null || PublicationList.Length == 0) return null;

			Paper? latest = PublicationList[0];
			latest = (Paper?)PublicationList.Where(x => x.PublicationTime > latest.PublicationTime).Select(x => x);

			return latest;
		}
	}

	public bool this[TimeFrame timeFrame]
	{
		get => ResearchDuration == timeFrame ? true : false;
	}


	/// <summary>Конструктор с инициализацией полей класса.</summary>
	public ResearchTeam(string researchTopic, string researchOrganization, int registrationNumber, 
		TimeFrame researchDuration, Paper[] publicationList)
	{
		_researchTopic = researchTopic;
		_researchOrganization = researchOrganization;
		_registrationNumber = registrationNumber;
		_researchDuration = researchDuration;
		_publicationList = publicationList;
	}

	/// <summary>Конструктор по умолчанию <see cref="ResearchTeam"/></summary>
	public ResearchTeam() : this("", "", 0, new TimeFrame(), Array.Empty<Paper>())
	{

	}

	/// <summary>Добавление газет в список публикаций.</summary>
	public void AddPapers(params Paper[] papers)
	{
		var publications = PublicationList;

		if(publications == null)
		{
			publications = papers;
		}
		else
		{
			int n = publications.Length;
			Array.Resize(ref publications, n + papers.Length);
			Array.Copy(papers, 0, publications, n, papers.Length);
		}
	}

	/// <summary>Формирования строки со значениями всех полей класса, включая список публикаций.</summary>
	public override string ToString()
	{
		var publication = PublicationList;

		string pubStr = publication == null || publication.Length == 0
		? "No publications"
		: string.Join("\n ", publication.ToList().Select(x => x));
		
		return  $"------------------\n" +
				$"Topic: {ResearchTopic}\n" +
				$"Organization: {ResearchOrganization}\n" +
				$"Registration number: {RegistrationNumber}\n" +
				$"Duration: {ResearchDuration}\n" +
				$"Publications: {pubStr}\n";
	}
	
	/// <summary>Формирует строку со значениями всех полей класса без списка публикаций.</summary>
	public virtual string ToShortString()
		=>  $"Topic: {ResearchTopic}\n" +
			$"Organization: {ResearchOrganization}\n" +
			$"Registration number: {RegistrationNumber}\n" +
			$"Duration: {ResearchDuration}";

}

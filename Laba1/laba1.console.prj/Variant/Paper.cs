namespace Laba1.Console.Variant;

/// <summary>Класс, содержащий информацию о газете.</summary>
public class Paper
{
	private string _publicationTitle = "Title";
	private Person _publicationAuthor = new();
	private DateTime _publicationTime = default;

	
	/// <summary>Свойство типа string для доступа к полю _publicationTitle.</summary>
	public string PublicationTitle
	{
		get => _publicationTitle;
		set => _publicationTitle = value;
	}

	/// <summary>Свойство типа Person для доступа к полю _publicationAuthor.</summary>
	public Person PublicationAuthor
	{
		get => _publicationAuthor;
		set => _publicationAuthor = value;
	}

	/// <summary>Свойство типа DateTime для доступа к полю _publicationTime.</summary>
	public DateTime PublicationTime
	{
		get => _publicationTime;
		set => _publicationTime = value;
	}

	/// <summary>Конструктор по умолчанию <see cref="Paper"/></summary>
	public Paper()
	{
		PublicationTitle = _publicationTitle;
		PublicationAuthor = _publicationAuthor;
		PublicationTime = _publicationTime;
	}

	/// <summary>Конструктор с инициализацией 3-х полей <see cref="Paper"/></summary>
	/// <param name="publicationTitle">Заголовок.</param>
	/// <param name="publicationAuthor">Автор.</param>
	/// <param name="publicationTime">Вермя публикации.</param>
	public Paper(string publicationTitle, Person publicationAuthor, DateTime publicationTime)
	{
		PublicationTitle = publicationTitle;
		PublicationAuthor = publicationAuthor;
		PublicationTime = publicationTime;
	}


	/// <summary>Возвращает строку с информацией о газете.</summary>
	public override string ToString()
		=>  $"Publication Title: {_publicationTitle}\n " +
			$"Publication Author: {_publicationAuthor}\n " +
			$"Publication Time: {_publicationTime}";
}
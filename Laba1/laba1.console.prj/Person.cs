namespace Laba1.Console;


/// <summary>Класс с информацией о человеке.</summary>
public class Person
{
	private string _name;
	private string _surname;
	private DateTime _dateOfBirth;


	/// <summary>Свойство типа string для доступа к полю с именем.</summary>
	public string Name
	{
		get => _name; 
		set => _name = value;
	}

	/// <summary>Свойство типа string для доступа к полю с фамилией.</summary>
	public string Surname
	{
		get => _surname;
		set => _surname = value;
	}

	/// <summary>Свойство типа DateTime для доступа к полю с датой рождения.</summary>
	public DateTime DateOfBirth
	{
		get => _dateOfBirth;
		set => _dateOfBirth = value;
	}

	/// <summary>Свойство типа int c методами get и set для получения информации(get) 
	/// и изменения (set) года рождения в закрытом поле типа DateTime, 
	/// в котором хранится дата рождения.</summary>
	public int BirthYear
	{                          
		get => _dateOfBirth.Year;
		set => _dateOfBirth = new DateTime(value, _dateOfBirth.Month, _dateOfBirth.Day);
	}


	/// <summary>Конструктор по умолчанию.</summary>
	public Person()
	{
		_name = "Никита";
		_surname = "Тимофеенко";
		_dateOfBirth = new DateTime(1999, 12, 31);

	}


	public Person(string name, string surname, DateTime dateOfBirth)
	{
		_name = name;
		_surname = surname;
		_dateOfBirth = dateOfBirth;
	}


	/// <summary>Возвращает строку с информацией о человеке.</summary>
	public override string ToString() => $"{_surname} {_name} : {_dateOfBirth}";

	/// <summary>Возвращает строку с именем и фамилией человека.</summary>
	protected virtual string ToShortString() => $"{_surname} {_name}";
}
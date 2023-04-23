using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2;

public class Person : INameAndCopy
{
    private string _name;
    private DateTime _birthDate;

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public DateTime BirthDate
    {
        get => _birthDate;
        set => _birthDate = value;
    }

    public Person()
    {
        Name = "Unknown";
        BirthDate = DateTime.MinValue;
    }

    public Person(string name, DateTime birthDate)
    {
        Name = name;
        BirthDate = birthDate;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Person other = (Person)obj;
        return Name == other.Name && BirthDate == other.BirthDate;
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode() ^ BirthDate.GetHashCode();
    }

    public virtual object DeepCopy()
    {
        return new Person(Name, BirthDate);
    }









}

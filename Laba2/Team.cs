using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2
{
    public class Team : INameAndCopy
    {
        protected string _organization;
        protected int _registrationNumber;

        public string Organization
        {
            get => _organization;
            set => _organization = value;
        }

        public int RegistrationNumber
        {
            get => _registrationNumber;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Регистрационный номер должен быть больше 0!");
                }
                _registrationNumber = value;
            }
        }

        public Team()
        {
            Organization = "Организация";
            RegistrationNumber = 0;
        }

        public Team(string organization, int registrationNumber)
        {
            Organization = organization;
            RegistrationNumber = registrationNumber;
        }

        public override string ToString()
            => $"Organization: {_organization}\n " +
                $"Registration Number: {_registrationNumber}";

        public virtual object DeepCopy()
        {
            return new Team(Organization, RegistrationNumber);
        }

        public string Name
        {
            get => _organization;
            set => _organization = value;
        }

        /// <summary>Метод Equals() переопределен таким образом, чтобы сравнение объектов типа Team происходило по значению их полей, а не по ссылкам на объекты.
        /// Для этого метод сначала проверяет, что переданный объект не null и является объектом типа Team, затем приводит его к типу Team и сравнивает значения всех полей.</summary>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Team other = (Team)obj;
            return _organization == other.Organization && _registrationNumber == other.RegistrationNumber;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_organization, _registrationNumber);
        }

        public static bool operator ==(Team team1, Team team2)
        {
            if (ReferenceEquals(team1, team2))
            {
                return true;
            }
            if (ReferenceEquals(team1, null) || ReferenceEquals(team2, null))
            {
                return false;
            }
            return team1.Equals(team2);
        }

        public static bool operator !=(Team team1, Team team2)
        {
            return !(team1 == team2);
        }
    }
}


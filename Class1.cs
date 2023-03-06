namespace LABA1
{
    enum TimeFrame {
        Year,
        TwoYears,
        Long
    }



    public class Person {                                                      // Класс Person с 3 закрытыми полями
        private string Name;
        private string Surname;
        private System.DateTime DateOfBirth;

        public Person(string Name, string Surname, DateTime DateOfBirth) {    // Конструктор с 3 параметрами класса
            this.Name = Name;
            this.Surname = Surname;
            this.DateOfBirth = DateOfBirth;
        }

        public Person() {                                                       // Конструктор без параметров 
            Name = "Никита";
            Surname = "Тимофеенко";
            DateOfBirth = new DateOfBirth(1999, 12, 31);

        }

        public string name {                                                 //  свойство типа string для доступа к полю с именем
            get { return Name; }
            set { Name = value; }
        }

        public string surname {                                              // свойство типа string для доступа к полю с фамилией
            get { return Surname; }
            set { Surname = value; }
        }

        public DateTime dateOfBirth {                                        // свойство типа DateTime для доступа к полю с датой рождения
            get { return DateOfBirth; }
            set { DateOfBirth = value; }
        }

        public int birthYear {                                               // свойство типа int c методами get и set для получения информации(get) и изменения (set) года рождения в закрытом поле типа DateTime, в котором хранится дата рождения                                 
            get { return DateOfBirth.Year; }
            set { DateOfBirth = new DateTime(value, DateOfBirth.Month, DateOfBirth.Day); }
        }

        public override string ToString() {
            return $"{Name} {Surname} {DateOfBirth}";
        }


    public class Programm
    {
        public static void Main(string[] args)
        {

        }
    }


    // Вариант 3


    public class Paper
    {
        public string PublicationTitle { set; get; }
        public Person PublicationAuthor { set; get; }
        public System.DateTime PublicationTime { set; get; }


        public Paper(string PublicationTitle, Person PublicationAuthor, System.DateTime PublicationTime)
        {
            this.PublicationTitle = PublicationTitle;
            this.PublicationAuthor = PublicationAuthor;
            this.PublicationTime = PublicationTime;
        }

        public Paper() {
            this.PublicationTitle = "Title";
            this.PublicationAuthor = "Author";
            this.PublicationTime = ;

        }

    public class ResearchTeam
    {
        private string ResearchTopic;
        private string ResearchOrganization;
        private int RegistrationNumber;
        private TimeFrame ResearchDuration;
        private Paper[] PublicationList;

        public ResearchTeam(string ResearchTopic, string ResearchOrganization, int RegistrationNumber, TimeFrame ResearchDuration, Paper[] PublicationList)
        {
            this.ResearchTopic = ResearchTopic;
            this.ResearchOrganization = ResearchOrganization;
            this.RegistrationNumber = RegistrationNumber;
            this.ResearchDuration = ResearchDuration;
            this.PublicationList = PublicationList;
        }

        public ResearchTeam()
        {
            this
        }
            
            
    }
    }
    }
}
using System;

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


    // Вариант 3


    public class Paper
    {
        public string PublicationTitle { get; set; }
        public Person PublicationAuthor { get; set; }
        public System.DateTime PublicationTime { get; set; }


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
        

        public ResearchTeam() : this("", "", 0, new TimeFrame(), new Paper[0]) {
        }

        public ResearchTeam(string topic, string organization, int registrationNumber) : this(topic, organization, registrationNumber, new TimeFrame(), new Paper[0]) {
        }

        public string researchTopic
        {
        get { return ResearchTopic; }
        set { ResearchTopic = value; }
        }

        public string researchOrganization
        {
        get { return ResearchOrganization; }
        set { ResearchOrganization = value; }
        }

        public int registrationNumber
        {
        get { return RegistrationNumber; }
        set { RegistrationNumber = value; }
        }

        public TimeFrame researchDuration
        {
        get { return ResearchDuration; }
        set { ResearchDuration = value; }
        }

        public Paper[] publicationList
        {
        get { return PublicationList; }
        set { PublicationList = value; }
        }
        
        public Paper LatestPublication
        {
            get
            {
                if (PublicationList == null || PublicationList.Length == 0)
                {
                    return null;
                }
                Paper latest = PublicationList[0];
                foreach (Paper p in PublicationList)
                {
                    if (p.PublicationDate > latest.PublicationDate)
                    {
                        latest = p;
                    }
                }
                return latest;
            }
        }

        public bool this[TimeFrame timeFrame]
        {
            get { return duration == timeFrame; }
        }

        public void AddPapers(params Paper[] papers)
        {
            if (publications == null)
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

        public override string ToString()
        {
            string pubStr = publications == null || publications.Length == 0
            ? "No publications"
            : string.Join("; ", publications);
            return $"Topic: {topic}; Organization: {organization}; Registration number: {registrationNumber}; Duration: {duration}; Publications: {pubStr}";
        }   

        public virtual string ToShortString()
        {
            return $"Topic: {topic}; Organization: {organization}; Registration number: {registrationNumber}; Duration: {duration}";
        }
        

        class Programm 
        {
            static void Main(string[] args)
            {   
                //1
                ResearchTeam team = new ResearchTeam("IT", "Team1", 11111, TimeFrame.TwoYears);
                Console.WriteLine(team.ToShortString());
                
                //2
                Console.WriteLine(team[TimeFrame.Year]);
                Console.WriteLine(team[TimeFrame.TwoYears]);
                Console.WriteLine(team[TimeFrame.Long]);

                //3
                team.ResearchTopic = "Topic";
                team.ResearchOrganization = "Organization";
                team.RegistrationNumber = 111;
                team.ResearchDuration = TimeFrame.Long;
                team.AddPapers(new Paper("Title 3", new Person("First 3", "Last 3", new DateTime(2000, 1, 1)), new DateTime(2000, 1, 1)));
                Console.WriteLine(team.ToString());

                //4
                team.AddPapers(new Paper("Title 2", new Person("First 2", "Last 2", new DateTime(2000, 1, 1)), new DateTime(2000, 1, 1)),
                               new Paper("Title 3", new Person("First 3", "Last 3", new DateTime(2000, 1, 1)), new DateTime(2000, 1, 1)));
                Console.WriteLine(team.ToString());

                //5
                Console.WriteLine(team.LatestPublication);

                //6
                int n = 1000000;
                Paper[] papers1 = new Paper[n];
                Stopwatch stopwatch1 = new Stopwatch();
                stopwatch1.Start();
                for (int i = 0; i < n; i++)
                {
                papers1[i] = new Paper($"Title {i}", new Person($"First {i}", $"Last {i}", new DateTime(2000, 1, 1)), new DateTime(2000, 1, 1));
                }
                stopwatch1.Stop();
                Console.WriteLine($"One-dimensional array: {stopwatch1.ElapsedMilliseconds} ms");

                // Операции с двумерным прямоугольным массивом Paper
                int rows = 1000;
                int cols = 1000;
                Paper[,] papers2 = new Paper[rows, cols];
                Stopwatch stopwatch2 = new Stopwatch();
                stopwatch2.Start();
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                    papers2[i, j] = new Paper($"Title {i} {j}", new Person($"First {i} {j}", $"Last {i} {j}", new DateTime(2000, 1, 1)), new DateTime(2000, 1, 1));
                    }
                }
                stopwatch2.Stop();
                Console.WriteLine($"Two-dimensional rectangular array: {stopwatch2.ElapsedMilliseconds} ms");

                // Операции с двумерным ступенчатым массивом Paper
                int[][] papers3 = new int[rows][];
                for (int i = 0; i < rows; i++)
                {
                    papers3[i] = new int[cols];
                }
                Stopwatch stopwatch3 = new Stopwatch();
                stopwatch3.Start();
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        papers3[i][j] = new Paper($"Title {i} {j}", new Person($"First {i} {j}", $"Last {i} {j}", new DateTime(2000, 1, 1)), new DateTime(2000, 1, 1));
                    }
                }
                


            }

        }

    }   
    }     
    }
    }
    }
}
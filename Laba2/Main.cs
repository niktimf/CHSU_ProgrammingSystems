using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Collections;

namespace Laba2
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Создание двух объектов типа Team с совпадающими данными
            Team team1 = new("Организация1", 1);
            Team team2 = new("Организация1", 1);

            // Проверка, что ссылки на объекты не равны, а объекты равны
            Console.WriteLine("team1 == team2: " + (team1 == team2));
            Console.WriteLine("team1.Equals(team2): " + team1.Equals(team2));

            // Вывод значений
            Console.WriteLine("team1 HashCode: " + team1.GetHashCode());
            Console.WriteLine("team2 HashCode: " + team2.GetHashCode());

            // 2. Присвоение свойству с номером регистрации некорректного значения
            try
            {
                team1.RegistrationNumber = -1;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }

            // 3. Объект типа ResearchTeam
            ResearchTeam researchTeam = new ResearchTeam("Организация1", 1, "Тема исследования", TimeFrame.TwoYears);

            // Добавление 
            researchTeam.AddPapers(new Paper("Статья 1", new Person("Иван", new DateTime(1990, 1, 1)), new DateTime(2022, 1, 1)));
            researchTeam.AddMembers(new Person("Иван", new DateTime(1990, 1, 1)), new Person("Петр", new DateTime(1991, 1, 1)));

            // Вывод данных объекта ResearchTeam
            Console.WriteLine(researchTeam.ToString());

            // 4. Вывод значений свойства Team для объекта типа ResearchTeam
            Console.WriteLine("ResearchTeamInfo: " + researchTeam.ResearchTeamInfo.ToString());

            // 5. Создание полных копий объекта ResearchTeam
            ResearchTeam researchTeamCopy = (ResearchTeam)researchTeam.DeepCopy();
            researchTeam.Organization = "Организация2";
            researchTeam.ResearchTopic = "Новая тема исследования";

            // Вывод копий и исходных объектов
            Console.WriteLine("Исходный объект: " + researchTeam.ToString());
            Console.WriteLine("Полная копия: " + researchTeamCopy.ToString());

            // 6. Вывод списков участников проекта, которые не имеют публикаций
            Console.WriteLine("Участники без публикаций:");
            foreach (Person person in researchTeam.MembersWithoutPublications)
            {
                Console.WriteLine(person.ToString());
            }

            // 7. Вывод списков всех публикаций, вышедших за последние два года
            Console.WriteLine();

            // 7. Вывести список всех публикаций, вышедших за последние два года
            Console.WriteLine("Публикации за последние два года:");
            foreach (Paper paper in researchTeam.GetPublicationsFromLastYears(2))
            {
                Console.WriteLine(paper);
      
            }
            // 8.Вывод списка участников проекта, у которых есть публикации.
            Console.WriteLine("Участники проекта с публикациями:");
            foreach (Person person in researchTeam)
            {
                Console.WriteLine(person.Name);
            }

            // 9. Вывод списка участников проекта, имеющих более одной публикации.
            Console.WriteLine("Участники проекта с более чем одной публикацией:");
            foreach (Person person in researchTeam.MembersWithMoreThanOnePublication())
            {
                Console.WriteLine(person.Name);
            }

            // 10. Вывод списка публикаций, вышедших за последний год.
            Console.WriteLine("Публикации за последний год:");
            foreach (Paper paper in researchTeam.PublicationsLastYear());


        }

    }
}

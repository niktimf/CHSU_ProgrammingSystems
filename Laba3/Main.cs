using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3;

class Program
{
    static void Main(string[] args)
    {
        // 1. Создание и заполнение коллекции ResearchTeam
        Laba3.ResearchTeamCollection researchTeamCollection = new Laba3.ResearchTeamCollection();
        researchTeamCollection.AddDefaults();
        Console.WriteLine(researchTeamCollection);

        // 2. Сортировка списка List<ResearchTeam> по разным критериям
        researchTeamCollection.SortByRegistrationNumber();
        Console.WriteLine(researchTeamCollection);

        researchTeamCollection.SortByResearchTopic();
        Console.WriteLine(researchTeamCollection);

        researchTeamCollection.SortByPublicationCount();
        Console.WriteLine(researchTeamCollection);

        // 3. Выполнение операций со списком List<ResearchTeam>
        // вычисление минимального значения номера регистрации для элементов списка
        Console.WriteLine(value: $"Min reg number: {researchTeamCollection.MinRegistrationNumber}");

        // фильтрация проектов с продолжительностью исследований TimeFrame.TwoYears
        var twoYearsResearchTeams = researchTeamCollection.ResearchTeamsGroupByTime(TimeFrame.TwoYears);
        foreach (var researchTeam in twoYearsResearchTeams)
        {
            Console.WriteLine(researchTeam);
        }

        // группировка элементов списка по числу публикаций
        var groupedByPublications = researchTeamCollection.GroupByPublicationsQuantity();
        foreach (var group in groupedByPublications)
        {
            Console.WriteLine($"Group of teams with {group.Key} publications:");
            foreach (var researchTeam in group)
            {
                Console.WriteLine(researchTeam);
            }
        }

        // 4. Создание объекта TestCollections и выполнение поиска в коллекциях
        TestCollections testCollections = new TestCollections(5); 
        testCollections.MeasureTimeForFirstElement();
        testCollections.MeasureTimeForMiddleElement();
        testCollections.MeasureTimeForLastElement();
        testCollections.MeasureTimeForNonexistentElement();
    }
}
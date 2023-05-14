using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Laba4.ResearchTeamCollection;

namespace Laba4;

class Program
{
    static void Main(string[] args)
    {
        // Создание двух коллекций ResearchTeamCollection
        ResearchTeamCollection teamCollection1 = new ResearchTeamCollection();
        ResearchTeamCollection teamCollection2 = new ResearchTeamCollection();

        // Создание двух объектов типа TeamsJournal
        TeamsJournal journal1 = new TeamsJournal();
        TeamsJournal journal2 = new TeamsJournal();

        // Подписываем первый журнал на события ResearchTeamAdded и ResearchTeamInserted из первой коллекции
        teamCollection1.ResearchTeamAdded += journal1.ResearchTeamAddedOrInsertedHandler;
        teamCollection1.ResearchTeamInserted += journal1.ResearchTeamAddedOrInsertedHandler;

        // Подписываем второй журнал на событие ResearchTeamInserted из обеих коллекций
        teamCollection1.ResearchTeamInserted += journal2.ResearchTeamAddedOrInsertedHandler;
        teamCollection2.ResearchTeamInserted += journal2.ResearchTeamAddedOrInsertedHandler;

        // Добавляем элементы в коллекции
        teamCollection1.AddDefaults();
        teamCollection2.AddDefaults();

        // С помощью метода InsertAt(int j, ResearchTeam rt) перед элементом с номером j, который есть в коллекции, вставляем новый элемент
        teamCollection1.InsertAt(0, new ResearchTeam());
        teamCollection2.InsertAt(0, new ResearchTeam());

        // Вызываем метод InsertAt(int j, ResearchTeam rt) с номером j, которого нет в коллекции
        teamCollection1.InsertAt(10, new ResearchTeam());
        teamCollection2.InsertAt(10, new ResearchTeam());

        // Выводим данные обоих объектов TeamsJournal
        Console.WriteLine($"Журнал 1 { journal1}");
        Console.WriteLine($"Журнал 1 {journal2}");
    }
}
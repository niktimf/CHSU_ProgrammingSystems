namespace Laba2.Console;

interface INameAndCopy
{
    string Name { get; set; }
    object DeepCopy();
}



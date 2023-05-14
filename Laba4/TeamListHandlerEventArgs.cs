using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba4;

public class TeamListHandlerEventArgs : EventArgs
{
    public string CollectionName { get; set; }
    public string ChangeType { get; set; }
    public int ElementIndex { get; set; }

    public TeamListHandlerEventArgs(string collectionName, string changeType, int elementIndex)
    {
        CollectionName = collectionName;
        ChangeType = changeType;
        ElementIndex = elementIndex;
    }

    public override string ToString()
    {
        return $"Collection Name: {CollectionName}, Change Type: {ChangeType}, Element Index: {ElementIndex}";
    }
}

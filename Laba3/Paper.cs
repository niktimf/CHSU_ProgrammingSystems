using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3;

public class Paper //: INameAndCopy
{
    private string _publicationTitle = "Title";
    private Person _publicationAuthor = new();
    private DateTime _publicationTime = default;

    public string PublicationTitle
    {
        get => _publicationTitle;
        set => _publicationTitle = value;
    }

    public Person PublicationAuthor
    {
        get => _publicationAuthor;
        set => _publicationAuthor = value;
    }

    public DateTime PublicationTime
    {
        get => _publicationTime;
        set => _publicationTime = value;
    }

    public Paper()
    {
        PublicationTitle = _publicationTitle;
        PublicationAuthor = _publicationAuthor;
        PublicationTime = _publicationTime;
    }

    public Paper(string publicationTitle, Person publicationAuthor, DateTime publicationTime)
    {
        PublicationTitle = publicationTitle;
        PublicationAuthor = publicationAuthor;
        PublicationTime = publicationTime;
    }

    public override string ToString()
        => $"Publication Title: {_publicationTitle}\n " +
            $"Publication Author: {_publicationAuthor}\n " +
            $"Publication Time: {_publicationTime}";

    public virtual object DeepCopy()
    {
        return new Paper(PublicationTitle, (Person)PublicationAuthor.DeepCopy(), PublicationTime);
    }
}

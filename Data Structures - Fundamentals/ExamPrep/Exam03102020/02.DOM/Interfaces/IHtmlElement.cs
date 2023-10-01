namespace _02.DOM.Interfaces
{
    using System.Collections.Generic;

    using _02.DOM.Models;

    public interface IHtmlElement
    {
        ElementType Type { get; set; }

        IHtmlElement Parent { get; set; }

        List<IHtmlElement> Children { get; }

        Dictionary<string, string> Attributes { get; }
    }
}

namespace _02.DOM.Interfaces
{
    using System.Collections.Generic;

    using _02.DOM.Models;

    public interface IDocument
    {
        IHtmlElement Root { get; }

        IHtmlElement GetElementByType(ElementType type);

        List<IHtmlElement> GetElementsByType(ElementType type);

        bool Contains(IHtmlElement htmlElement);

        void InsertFirst(IHtmlElement parent, IHtmlElement child);

        void InsertLast(IHtmlElement parent, IHtmlElement child);

        void Remove(IHtmlElement htmlElement);

        void RemoveAll(ElementType elementType);

        bool AddAttribute(string attrKey, string attrValue, IHtmlElement htmlElement);

        bool RemoveAttribute(string attrKey, IHtmlElement htmlElement);

        IHtmlElement GetElementById(string idValue);
    }
}

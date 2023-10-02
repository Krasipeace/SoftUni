namespace _02.DOM.Models
{
    using System;
    using System.Collections.Generic;

    using _02.DOM.Interfaces;

    public class HtmlElement : IHtmlElement
    {
        public HtmlElement(ElementType type, params IHtmlElement[] children)
        {
            this.Type = type;
            this.Children = new List<IHtmlElement>();
            this.Children.AddRange(children);
            this.Attributes = new Dictionary<string, string>();
        }

        public ElementType Type { get; set; }

        public IHtmlElement Parent { get; set; }

        public List<IHtmlElement> Children { get; }

        public Dictionary<string, string> Attributes { get; }
    }
}

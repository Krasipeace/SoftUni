namespace _02.DOM
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using _02.DOM.Interfaces;
    using _02.DOM.Models;

    public class DocumentObjectModel : IDocument
    {
        public DocumentObjectModel(IHtmlElement root)
        {
            this.Root = root;
        }

        public DocumentObjectModel()
        {
            this.Root =
                new HtmlElement(ElementType.Document,
                    new HtmlElement(ElementType.Html,
                        new HtmlElement(ElementType.Head),
                        new HtmlElement(ElementType.Body)
            ));
        }

        public IHtmlElement Root { get; private set; }

        public IHtmlElement GetElementByType(ElementType type)
        {
            var elementsByType = new Queue<IHtmlElement>();
            elementsByType.Enqueue(Root);

            while (elementsByType.Count > 0)
            {
                var currentElement = elementsByType.Dequeue();

                if (currentElement.Type == type)
                {
                    return currentElement;
                }

                foreach (var child in currentElement.Children)
                {
                    elementsByType.Enqueue(child);
                }
            }

            return null;
        }

        public List<IHtmlElement> GetElementsByType(ElementType type)
        {
            var elements = new List<IHtmlElement>();
            
            DfsElements(this.Root, type, elements);

            return elements;
        }

        private void DfsElements(IHtmlElement root, ElementType type, List<IHtmlElement> elements)
        {
            foreach (var child in root.Children)
            {
                DfsElements(child, type, elements);
            }

            if (root.Type == type)
            {
                elements.Add(root);
            }
        }

        public bool Contains(IHtmlElement htmlElement)
        {
            var queue = new Queue<IHtmlElement>();
            queue.Enqueue(this.Root);

            while (queue.Count > 0)
            {
                var currentElement = queue.Dequeue();

                if (currentElement == htmlElement)
                {
                    return true;
                }

                foreach (var child in currentElement.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return false;
        }

        public void InsertFirst(IHtmlElement parent, IHtmlElement child)
        {
            IsThereValue(parent);

            parent.Children.Insert(0, child);
            child.Parent = parent;
        }

        public void InsertLast(IHtmlElement parent, IHtmlElement child)
        {
            IsThereValue(parent);

            parent.Children.Add(child);
            child.Parent = parent;
        }

        public void Remove(IHtmlElement htmlElement)
        {
            if (!Contains(htmlElement))
            {
                throw new InvalidOperationException();
            }

            htmlElement.Parent.Children.Remove(htmlElement);
            htmlElement.Parent = null;
            htmlElement.Children.Clear();
        }

        public void RemoveAll(ElementType elementType)
        {
            var removeElements = this.GetElementsByType(elementType);
            foreach (var item in removeElements)
            {
                this.Remove(item);
            }
        }

        public bool AddAttribute(string attrKey, string attrValue, IHtmlElement htmlElement)
        {
            if (!this.Contains(htmlElement))
            {
                throw new InvalidOperationException();
            }

            if (htmlElement.Attributes.ContainsKey(attrKey))
            {
                return false;
            }

            htmlElement.Attributes.Add(attrKey, attrValue);

            return true;
        }

        public bool RemoveAttribute(string attrKey, IHtmlElement htmlElement)
        {
            if (!this.Contains(htmlElement))
            {
                throw new InvalidOperationException();
            }

            if (!htmlElement.Attributes.ContainsKey(attrKey))
            {
                return false;
            }

            htmlElement.Attributes.Remove(attrKey);

            return true;
        }

        public IHtmlElement GetElementById(string idValue)
        {
            var elements = new Queue<IHtmlElement>();
            elements.Enqueue(Root);
            
            while (elements.Count > 0)
            {
                var currentElement = elements.Dequeue();

                if (currentElement.Attributes.ContainsKey("id") && currentElement.Attributes["id"] == idValue)
                {
                    return currentElement;
                }

                foreach (var child in currentElement.Children)
                {
                    elements.Enqueue(child);
                }
            }

            return null;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var indent = 0;
            GetDomTreeToString(this.Root, sb, ref indent);

            return sb.ToString();
        }

        private static void GetDomTreeToString(IHtmlElement element, StringBuilder sb, ref int indent)
        {
            var prefix = new string(' ', indent);
            sb.AppendLine($"{prefix}{element.Type}");

            if (element.Children.Count > 0)
            {
                indent += 2;
                foreach (var child in element.Children)
                {
                    GetDomTreeToString(child, sb, ref indent);
                }
            }
        }

        private IHtmlElement FindElement(IHtmlElement node, IHtmlElement element)
        {
            if (node == element)
            {
                return node;
            }

            foreach (var child in element.Children)
            {
                return FindElement(node, child);
            }

            return null;
        }

        private void IsThereValue(IHtmlElement nodeElement)
        {
            if (nodeElement == null)
            {
                throw new InvalidOperationException();
            }
        }
    }
}

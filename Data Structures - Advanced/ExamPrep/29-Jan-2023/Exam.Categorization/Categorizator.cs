using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.Categorization
{
    public class Categorizator : ICategorizator
    {
        private Dictionary<string, Category> categoriesById;

        public Categorizator()
        {
            this.categoriesById = new Dictionary<string, Category>();
        }

        public void AddCategory(Category category)
        {
            if (categoriesById.ContainsKey(category.Id))
            {
                throw new ArgumentException();
            }

            categoriesById.Add(category.Id, category);
        }

        public void AssignParent(string childCategoryId, string parentCategoryId)
        {
            if (!categoriesById.ContainsKey(childCategoryId) || !categoriesById.ContainsKey(parentCategoryId))
            {
                throw new ArgumentException();
            }

            var childCategory = categoriesById[childCategoryId];
            var parentCategory = categoriesById[parentCategoryId];

            if (childCategory.Parent != null)
            {
                throw new ArgumentException();
            }

            childCategory.Parent = parentCategory;
            parentCategory.Children.Add(childCategory);
        }

        public int Size()
            => this.categoriesById.Count;

        public bool Contains(Category category)
            => categoriesById.ContainsKey(category.Id);

        public IEnumerable<Category> GetChildren(string categoryId)
        {
            if (!categoriesById.ContainsKey(categoryId))
            {
                throw new ArgumentException();
            }

            var children = new HashSet<Category>();
            GetAllChildren(categoryId, children);

            return children;
        }

        private void GetAllChildren(string categoryId, HashSet<Category> children)
        {
            foreach (var child in categoriesById[categoryId].Children)
            {
                children.Add(child);
                GetAllChildren(child.Id, children);
            }
        }

        public IEnumerable<Category> GetHierarchy(string categoryId)
        {
            if (!categoriesById.ContainsKey(categoryId))
            {
                throw new ArgumentException();
            }

            var hierarchy = new Stack<Category>();

            GetAllParents(categoriesById[categoryId], hierarchy);

            return hierarchy;
        }

        private void GetAllParents(Category category, Stack<Category> hierarchy)
        {
            if (category.Parent != null)
            {
                hierarchy.Push(category.Parent);
                GetAllParents(category.Parent, hierarchy);
            }
        }

        public void RemoveCategory(string categoryId)
        {
            if (!categoriesById.ContainsKey(categoryId))
            {
                throw new ArgumentException();
            }

            var categoryToRemove = categoriesById[categoryId];
            categoriesById.Remove(categoryId);

            RemoveChildren(categoryToRemove);

            if (categoryToRemove.Parent != null)
            {
                categoryToRemove.Parent.Children.Remove(categoryToRemove);
            }
        }

        private void RemoveChildren(Category categoryToRemove)
        {
            foreach (var child in categoryToRemove.Children)
            {
                RemoveChildren(child);
                categoriesById.Remove(child.Id);
            }
        }

        public IEnumerable<Category> GetTop3CategoriesOrderedByDepthOfChildrenThenByName()
            => this.categoriesById.Values
                .OrderByDescending(c => GetChildren(c.Id).Count())
                .ThenBy(c => c.Name.Length)
                .Take(3);
    }
}

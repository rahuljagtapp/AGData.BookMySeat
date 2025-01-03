using System;

namespace AGData.BookMySeat.Domain.Entities
{
    public class Resource
    {
        public Guid ResourceId { get; private set; }
        public string ResourceCategory { get; private set; }
        public string ResourceName { get; private set; }

        private Resource() { }

        public Resource(string resourceCategory, string resourceName)
        {
            ResourceId = Guid.NewGuid();
            ResourceCategory = resourceCategory;
            ResourceName = resourceName;
        }

        public void UpdateResourceName(string newName)
        {
            if (!string.IsNullOrWhiteSpace(newName))
            {
                ResourceName = newName;
            }
        }

        public void UpdateResourceCategory(string newCategory)
        {
            if (!string.IsNullOrWhiteSpace(newCategory))
            {
                ResourceCategory = newCategory;
            }
        }
    }
}

using System;

namespace Timesheet.Core
{
    public class CategoryName
    {
        private readonly string categoryName;

        public CategoryName(string categoryName)
        {
                if (string.IsNullOrWhiteSpace(categoryName))
                {
                    throw new ArgumentException("Category name cannot be empty");
                }

                if (categoryName.Length > 100)
                {
                    throw new ArgumentException("Category name cannot be greater than 100 characters");
                }

                this.categoryName = categoryName;
        }
    }
}
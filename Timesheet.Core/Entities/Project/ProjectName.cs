﻿using CSharpFunctionalExtensions;
using System;

namespace Timesheet.Core
{
    public class ProjectName
    {
        private readonly string value;
        public ProjectName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Project name cannot be empty");
            }

            if (name.Length > 100)
            {
                throw new ArgumentException("Project name cannot be greater than 100 characters");
            }
            this.value = name;
        }

        public bool Contains(SearchText text)
        {
            if (text.IsEmpty)
                return true;

            return this.value.Contains(text.ToString(), StringComparison.OrdinalIgnoreCase);
        }

        public bool StartsWith(Maybe<FirstLetter> maybeFirstLetter)
        {
            if (maybeFirstLetter.HasValue)
            {
                return this.value.StartsWith(maybeFirstLetter.Value, StringComparison.OrdinalIgnoreCase);
            }

            return true;
        }

        public static implicit operator string(ProjectName name) => name.value;
        public override string ToString()
        {
            return value;
        }
    }
}
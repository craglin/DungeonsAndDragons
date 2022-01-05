using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDragons
{
    public class Name
    {
        public string FirstName { get; }
        public string MiddleName { get; }
        public string LastName { get; }
        public string Title { get; }

        public string FullName
        {
            get { return $"{FirstName} {MiddleName} {LastName}"; }
        }

        public string NameTitle
        {
            get { return $"{FirstName} {LastName}, {Title}"; }
        }

        /// <summary>
        /// Name constructor
        /// </summary>
        public Name(string firstName, string middleName, string lastName, string title)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Title = title;
        }

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            MiddleName = "";
            LastName = lastName;
            Title = "";
        }

    }
}

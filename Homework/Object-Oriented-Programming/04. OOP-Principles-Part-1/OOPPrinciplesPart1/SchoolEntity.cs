using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPPrinciplesPart1
{
    public abstract class SchoolEntity : ISchoolEntity
    {
        protected SchoolEntity(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
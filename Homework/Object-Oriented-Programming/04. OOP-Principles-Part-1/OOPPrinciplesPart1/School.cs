using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPPrinciplesPart1
{
    public class School : ISchool
    {
        public School(string name, string address)
        {
            this.Name = name;
            this.Address = address;
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public List<SchoolClass> Classes { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPPrinciplesPart1
{
    public interface IComments
    {
        /// <summary>
        /// Optional block of comments
        /// </summary>
        string Comments { get; set; }

        void AddComment(string comment);
    }
}
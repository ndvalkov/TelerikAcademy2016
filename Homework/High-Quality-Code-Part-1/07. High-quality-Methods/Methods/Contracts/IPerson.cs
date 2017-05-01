using System;

namespace Methods.Contracts
{
    public interface IPerson
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime DateOfBirth { get; set; }

        bool IsOlderThan(IPerson other);
    }
}
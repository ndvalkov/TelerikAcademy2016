namespace Methods.Contracts
{
    public interface IStudent : IPerson
    {
        string Town { get; set; }
        Student.AcademyResult Result { get; set; }
        string Occupation { get; set; }
        string Description { get; }
    }
}
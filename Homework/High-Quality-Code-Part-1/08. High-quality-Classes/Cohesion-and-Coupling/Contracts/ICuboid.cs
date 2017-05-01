namespace CohesionAndCoupling.Contracts
{
    public interface ICuboid
    {
        double CalculateVolume();
        double CalculateDiagonalXYZ();
        double CalculateDiagonalXY();
        double CalculateDiagonalXZ();
        double CalculateDiagonalYZ();
    }
}
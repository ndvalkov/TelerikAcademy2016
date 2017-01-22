using System;

class QuadraticEquation
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());

        double sqrtPart = (b * b) - (4 * a * c);
        bool hasNoRoots = sqrtPart < 0;
        // if no roots set 0 to avoid Exception
        sqrtPart = hasNoRoots ? 0 : sqrtPart;

        double firstRoot = (-b + Math.Sqrt(sqrtPart)) / (2 * a);
        double secondRoot = (-b - Math.Sqrt(sqrtPart)) / (2 * a);

        // swap to meet problem requirement: <Print the smaller root on the first line>
        bool isFirstGreater = firstRoot > secondRoot;
        double tempRoot = firstRoot;
        firstRoot = isFirstGreater ? secondRoot : firstRoot;
        secondRoot = isFirstGreater ? tempRoot : secondRoot;

        bool hasOneRoot = (sqrtPart == 0);
        string oneRootFormat = "{0:0.00}";
        string twoRootFormat = "{0:0.00}\n{1:0.00}";
        string result = hasOneRoot ? 
            String.Format(oneRootFormat, firstRoot) :
            String.Format(twoRootFormat, firstRoot, secondRoot);

        Console.WriteLine(hasNoRoots ? "no real roots" : result);
    }
}
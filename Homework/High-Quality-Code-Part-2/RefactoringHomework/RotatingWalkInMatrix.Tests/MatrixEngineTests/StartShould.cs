namespace RotatingWalkInMatrix.Tests.MatrixEngineTests
{
    using System;
    using System.IO;
    using Mocks;
    using NUnit.Framework;
    using RefactoringHomework.RotatingWalkInMatrix.Engine;

    [TestFixture]
    public class StartShould
    {
        [Test]
        public void PrintCorrectResult_WhenCalledWithSize3()
        {
            // Arrange
            var instance = MatrixEngine.Instance;
            var testFilename = "TestOutputOfMatrixSize3.txt";
            var consoleStub = new FileConsole(testFilename);

            instance.Size = 3;
            instance.MatrixConsole = consoleStub;

            // Act
            instance.Start();
            consoleStub.Dispose();
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var result = File.ReadAllText(path + '\\' + testFilename);
            File.Delete(path + '\\' + testFilename);
            var expected = @"  1  7  8
  6  2  9
  5  4  3
";

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void PrintCorrectResult_WhenCalledWithSize5()
        {
            // Arrange
            var instance = MatrixEngine.Instance;
            var testFilename = "TestOutputOfMatrixSize5.txt";
            var consoleStub = new FileConsole(testFilename);

            instance.Size = 5;
            instance.MatrixConsole = consoleStub;

            // Act
            instance.Start();
            consoleStub.Dispose();
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var result = File.ReadAllText(path + '\\' + testFilename);
            File.Delete(path + '\\' + testFilename);
            
            var expected = @"  1 13 14 15 16
 12  2 21 22 17
 11 23  3 20 18
 10 25 24  4 19
  9  8  7  6  5
";

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void PrintCorrectResult_WhenCalledWithSize6()
        {
            // Arrange
            var instance = MatrixEngine.Instance;
            var testFilename = "TestOutputOfMatrixSize6.txt";
            var consoleStub = new FileConsole(testFilename);

            instance.Size = 6;
            instance.MatrixConsole = consoleStub;

            // Act
            instance.Start();
            consoleStub.Dispose();
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var result = File.ReadAllText(path + '\\' + testFilename);
            File.Delete(path + '\\' + testFilename);

            var expected = @"  1 16 17 18 19 20
 15  2 27 28 29 21
 14 31  3 26 30 22
 13 36 32  4 25 23
 12 35 34 33  5 24
 11 10  9  8  7  6
";
            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void PrintCorrectResult_WhenCalledWithSize11()
        {
            // Arrange
            var instance = MatrixEngine.Instance;
            var testFilename = "TestOutputOfMatrixSize11.txt";
            var consoleStub = new FileConsole(testFilename);

            instance.Size = 11;
            instance.MatrixConsole = consoleStub;

            // Act
            instance.Start();
            consoleStub.Dispose();
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var result = File.ReadAllText(path + '\\' + testFilename);
            File.Delete(path + '\\' + testFilename);

            var expected = @"  1 31 32 33 34 35 36 37 38 39 40
 30  2 57 58 59 60 61 62 63 64 41
 29 86  3 56 75 76 77 78 79 65 42
 28106 87  4 55 74 84 85 80 66 43
 27105107 88  5 54 73 83 81 67 44
 26104118108 89  6 53 72 82 68 45
 25103117119109 90  7 52 71 69 46
 24102116121120110 91  8 51 70 47
 23101115114113112111 92  9 50 48
 22100 99 98 97 96 95 94 93 10 49
 21 20 19 18 17 16 15 14 13 12 11
";
            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
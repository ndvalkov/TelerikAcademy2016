namespace RotatingWalkInMatrix.Tests.MatrixEngineTests
{
    using NUnit.Framework;
    using RefactoringHomework.RotatingWalkInMatrix.Engine;

    [TestFixture]
    public class InstanceShould
    {
        [Test]
        public void ReturnInstanceOfMatrixEngine_WhenCalled()
        {
            // Arrange & Act
            var instance = MatrixEngine.Instance;

            // Assert
            Assert.IsInstanceOf<MatrixEngine>(instance);
        }
    }
}
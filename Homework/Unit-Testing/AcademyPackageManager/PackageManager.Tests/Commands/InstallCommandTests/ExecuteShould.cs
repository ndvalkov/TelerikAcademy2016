using Moq;
using NUnit.Framework;
using PackageManager.Core.Contracts;
using PackageManager.Enums;
using PackageManager.Models.Contracts;
using PackageManager.Tests.Fakes;

namespace PackageManager.Tests.Commands.InstallCommandTests
{
    [TestFixture]
    public class ExecuteShould
    {
        [Test]
        public void CallPerformOperationWithPassedTheRespectivePackage_WhenCalledWithValidParameters()
        {
            // Arrange
            var installerMock = new Mock<IInstaller<IPackage>>();
            var packageMock = new Mock<IPackage>();

            var installCommand = new FakeInstallCommand(installerMock.Object, packageMock.Object);

            // Act
            installCommand.Execute();

            // Assert
            installerMock.Verify(x => x.PerformOperation(packageMock.Object), Times.Once());
        }
    }
}
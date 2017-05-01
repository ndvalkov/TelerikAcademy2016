using System;
using Moq;
using NUnit.Framework;
using PackageManager.Commands;
using PackageManager.Core.Contracts;
using PackageManager.Enums;
using PackageManager.Models.Contracts;
using PackageManager.Tests.Fakes;

namespace PackageManager.Tests.Commands.InstallCommandTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void SetCorrectly_WhenPassedValidInstaller()
        {
            // Arrange
            var installerMock = new Mock<IInstaller<IPackage>>();
            var packageMock = new Mock<IPackage>();

            // Act
            var installCommand = new FakeInstallCommand(installerMock.Object, packageMock.Object);

            // Assert
            Assert.AreSame(installerMock.Object, installCommand.Installer);
        }

        [Test]
        public void SetCorrectly_WhenPassedValidPackage()
        {
            // Arrange
            var installerMock = new Mock<IInstaller<IPackage>>();
            var packageMock = new Mock<IPackage>();

            // Act
            var installCommand = new FakeInstallCommand(installerMock.Object, packageMock.Object);

            // Assert
            Assert.AreSame(packageMock.Object, installCommand.Package);
        }

        [Test]
        public void ThrowArgumentNullException_WhenPassedInstallerIsNull()
        {
            // Arrange
            IInstaller<IPackage> invalidInstaller = null;
            var packageMock = new Mock<IPackage>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new FakeInstallCommand(invalidInstaller, packageMock.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenPassedPackageIsNull()
        {
            // Arrange
            var installerMock = new Mock<IInstaller<IPackage>>();
            IPackage invalidPackage = null;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new FakeInstallCommand(installerMock.Object, invalidPackage));
        }

        [Test]
        public void SetPropertyOperationOfTheInstallerWithCorrectValue_WhenCalledWithValidParameters()
        {
            // Arrange
            var installerMock = new Mock<IInstaller<IPackage>>();
            var packageMock = new Mock<IPackage>();

            // Act
            var installCommand = new FakeInstallCommand(installerMock.Object, packageMock.Object);

            // Assert
            installerMock.VerifySet(x => x.Operation = InstallerOperation.Install, Times.Once());
        }
    }
}
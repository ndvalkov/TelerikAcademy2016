using System;
using NUnit.Framework;
using PackageManager.Enums;
using PackageManager.Models;

namespace PackageManager.Tests.Models.PackageVersionTests
{
    [TestFixture]
    public class VersionTypeShould
    {
        [Test]
        public void GetCorrectResult_WhenValidVersionTypeIsPassedToTheConstructor()
        {
            // Arrange
            var major = 1;
            var minor = 2;
            var expectedPatch = 1;
            var versionType = VersionType.alpha;

            var packageVersion = new PackageVersion(major, minor, expectedPatch, versionType);

            // Act
            var result = packageVersion.Patch;

            // Assert
            Assert.AreEqual(expectedPatch, result);
        }

        [Test]
        public void NotThrowException_WhenValidVersionTypeIsPassedToTheConstructor()
        {
            // Arrange
            var major = 1;
            var minor = 2;
            var patch = 1;
            var versionType = VersionType.alpha;

            // Act and Assert
            Assert.DoesNotThrow(() => new PackageVersion(major, minor, patch, versionType));
        }

        [Test]
        public void ThrowArgumentException_WhenInvalidVersionTypeIsPassedToTheConstructor()
        {
            // Arrange
            var major = 1;
            var minor = 2;
            var patch = 1;

            var invalidVersionType = Enum.GetValues(typeof(VersionType)).Length + 1;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => new PackageVersion(major, minor, patch, (VersionType)invalidVersionType));
        }
    }
}
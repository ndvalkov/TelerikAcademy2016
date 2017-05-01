using System;
using NUnit.Framework;
using PackageManager.Enums;
using PackageManager.Models;

namespace PackageManager.Tests.Models.PackageVersionTests
{
    [TestFixture]
    public class MinorShould
    {
        [Test]
        public void GetCorrectResult_WhenValidMinorIsPassedToTheConstructor()
        {
            // Arrange
            var major = 1;
            var expectedMinor = 2;
            var patch = 1;
            var versionType = VersionType.alpha;

            var packageVersion = new PackageVersion(major, expectedMinor, patch, versionType);

            // Act
            var result = packageVersion.Minor;

            // Assert
            Assert.AreEqual(expectedMinor, result);
        }

        [Test]
        public void NotThrowException_WhenValidMinorIsPassedToTheConstructor()
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
        public void ThrowArgumentException_WhenInvalidMinorIsPassedToTheConstructor()
        {
            // Arrange
            var major = 1;
            var invalidMinor = -2;
            var patch = 1;
            var versionType = VersionType.alpha;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => new PackageVersion(major, invalidMinor, patch, versionType));
        }
    }
}
using PackageManager.Commands;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;

namespace PackageManager.Tests.Fakes
{
    internal class FakeInstallCommand : InstallCommand
    {
        public FakeInstallCommand(IInstaller<IPackage> installer, IPackage package) : base(installer, package)
        {
        }

        public IInstaller<IPackage> Installer
        {
            get { return installer; }
        }

        public IPackage Package
        {
            get { return package; }
        }
    }
}
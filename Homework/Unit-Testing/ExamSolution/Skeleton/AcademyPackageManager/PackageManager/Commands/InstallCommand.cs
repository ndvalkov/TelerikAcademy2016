using PackageManager.Commands.Contracts;
using PackageManager.Core.Contracts;
using PackageManager.Enums;
using PackageManager.Models.Contracts;
using System;

namespace PackageManager.Commands
{
    internal class InstallCommand : ICommand
    {
        // changed access level for testing purposes
        protected IInstaller<IPackage> installer;
        // changed access level for testing purposes
        protected IPackage package;

        public InstallCommand(IInstaller<IPackage> installer, IPackage package)
        {
            if(installer == null)
            {
                throw new ArgumentNullException();
            }

            if (package == null)
            {
                throw new ArgumentNullException();
            }

            this.installer = installer;
            this.package = package;
            this.installer.Operation = InstallerOperation.Install;
        }

        public void Execute()
        {
            this.installer.PerformOperation(this.package);
        }
    }
}

using System;

namespace Attributes
{
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class |
        AttributeTargets.Interface | AttributeTargets.Enum | AttributeTargets.Method)]

    public class MyVersion : Attribute
    {
        public string Version { get; private set; }

        public MyVersion(string version)
        {
            Version = version;
        }
    }
}

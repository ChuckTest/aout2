using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn.UnitTests
{
    internal class TestableLogAnalyzer : LogAnalyzer3464UsingFactoryMethod
    {
        public TestableLogAnalyzer(IExtensionManager mgr)
        {
            Manager = mgr;
        }

        public IExtensionManager Manager;
        protected override IExtensionManager GetManager()
        {
            return Manager;
        }
    }
}

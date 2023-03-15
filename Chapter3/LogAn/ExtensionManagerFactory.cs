using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn
{
    public class ExtensionManagerFactory
    {
        private static IExtensionManager customExtensionManager = null;

        public static IExtensionManager Create()
        {
            if (customExtensionManager != null)
            {
                return customExtensionManager;
            }

            return new FileExtensionManager();
        }

        public static void SetManager(IExtensionManager mgr)
        {
            customExtensionManager = mgr;
        }
    }
}

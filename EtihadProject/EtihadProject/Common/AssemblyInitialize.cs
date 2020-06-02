using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EtihadProject.Common
{

    [TestClass]
    public class AssemblyInitialize
    {

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext testContext)
        {
            //Excel Reader Init
            Reporters.StartReporter();
        }

    }
}

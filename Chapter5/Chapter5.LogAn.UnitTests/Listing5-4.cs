using NSubstitute;
using NUnit.Framework;

namespace Chapter5.LogAn.UnitTests
{
    [TestFixture]
    public class Listing5_4
    {
        //Returning a value from a fake object
        [Test]
        public void Returns_ByDefault_WorksForHardCodeArgument()
        {
            IFileNameRules fakeRules = Substitute.For<IFileNameRules>();

            fakeRules.IsValidLogFileName("strict.txt").Returns(true);//forces method call to return fake value

            Assert.IsTrue(fakeRules.IsValidLogFileName("strict.txt"));
        }
    }
}

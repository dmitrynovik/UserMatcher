using NUnit.Framework;
using System;
using UserMatcher.Lib;
using UserMatcher.Lib.Matchers;

namespace UserMatcher.UnitTest
{
    [TestFixture]
    public class AddressMatcherTest : TestBase
    {
        [Test]
        public void When_Name_And_Address_Equals_Is_Match()
        {
            var u1 = CreateCorruptedAddressUser();
            var u2 = CreateGoodAddressUser();
            var matcher = new AddressMatcher();

            Assert.IsTrue(matcher.IsMatch(u1, u2));
        }
    }
}

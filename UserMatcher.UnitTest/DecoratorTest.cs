using NUnit.Framework;
using System;
using UserMatcher.Lib;
using UserMatcher.Lib.Matchers;

namespace UserMatcher.UnitTest
{
    /// <summary>
    /// This tests demonstrates the decorator design pattern (if you prefer it over composition).
    /// </summary>
    [TestFixture]
    public class DecoratorTest : TestBase
    {
        [Test]
        public void When_Any_Decorated_Matcher_Returns_Match_Decorator_Returns_Match()
        {
            var decorator = new ReferralCodeMatcher(
                new AddressMatcher(
                    new GeographicalDistanceMatcher(
                        new BasicMatcher())));

            var u1 = CreateCorruptedAddressUser();
            var u2 = CreateGoodAddressUser();

            Assert.IsTrue(decorator.IsMatch(u1, u2));
        }
    }
}

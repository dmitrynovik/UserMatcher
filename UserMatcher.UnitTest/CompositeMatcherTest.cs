using NUnit.Framework;
using System;
using UserMatcher.Lib;
using UserMatcher.Lib.Matchers;

namespace UserMatcher.UnitTest
{
    [TestFixture]
    public class CompositeMatcherTest : TestBase
    {
        [Test]
        public void When_Any_Matcher_Returns_Match_Composition_Returns_Match()
        {
            var composition = new CompositeMatcher(
                new GeographicalDistanceMatcher(),
                new AddressMatcher(),
                new ReferralCodeMatcher()
                );

            var u1 = CreateCorruptedAddressUser();
            var u2 = CreateGoodAddressUser();

            Assert.IsTrue(composition.IsMatch(u1, u2));
        }

    }
}

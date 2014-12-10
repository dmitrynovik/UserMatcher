using NUnit.Framework;
using System;
using UserMatcher.Lib;
using UserMatcher.Lib.Matchers;

namespace UserMatcher.UnitTest
{
    [TestFixture]
    public class ReferralCodeTest
    {
        [Test]
        public void ABC123_Match_AB213C()
        {
            var u1 = new User() { ReferralCode = "ABC123" };
            var u2 = new User() { ReferralCode = "AB21C3" };
            var matcher = new ReferralCodeMatcher();

            Assert.IsTrue(matcher.IsMatch(u1, u2));
        }

        [Test]
        public void ABC123_Match_ABC321()
        {
            var u1 = new User() { ReferralCode = "ABC123" };
            var u2 = new User() { ReferralCode = "ABC321" };
            var matcher = new ReferralCodeMatcher();

            Assert.IsTrue(matcher.IsMatch(u1, u2));
        }
    }
}

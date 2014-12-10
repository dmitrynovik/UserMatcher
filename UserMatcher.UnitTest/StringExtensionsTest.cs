using System;
using NUnit.Framework;
using UserMatcher.Lib;

namespace UserMatcher.UnitTest
{
    [TestFixture]
    public class StringExtensionsTest
    {
        [Test]
        public void When_Empty_Returns_Empty()
        {
            Assert.AreEqual("", "".ToTitleCase());
        }

        [Test]
        public void When_SingleChar_Returns_UpperCase()
        {
            Assert.AreEqual("T", "t".ToTitleCase());
        }

        [Test]
        public void When_FullName_Returns_Titlecase()
        {
            Assert.AreEqual("Tom Hanks", "tom hanks".ToTitleCase());
        }
    }
}

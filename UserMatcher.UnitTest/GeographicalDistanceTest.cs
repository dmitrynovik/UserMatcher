using NUnit.Framework;
using System;
using UserMatcher.Lib;
using UserMatcher.Lib.Matchers;

namespace UserMatcher.UnitTest
{
    [TestFixture]
    public class GeographicalDistanceTest
    {
        [Test]
        public void Two_Users_On_The_Same_Pole_Match()
        {
            var u1 = CreateGeoUser(90, 0);
            var u2 = CreateGeoUser(90, 180);
            var matcher = new GeographicalDistanceMatcher();

            Assert.IsTrue(matcher.IsMatch(u1, u2));
        }

        [Test]
        public void Moscow_And_New_York_Do_Not_Match()
        {
            var u1 = CreateGeoUser(55.75m, 37.6m);
            var u2 = CreateGeoUser(40.7m, -74.0m);
            var matcher = new GeographicalDistanceMatcher();

            Assert.IsFalse(matcher.IsMatch(u1, u2));
        }

        private static User CreateGeoUser(decimal latitude, decimal longitude)
        {
            return new User 
            { 
                Address = new Address { Latitude = latitude, Longitude = longitude } 
            };
        }
    }
}

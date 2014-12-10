using System;
using UserMatcher.Lib;
using UserMatcher.Lib.Matchers;

namespace UserMatcher.UnitTest
{
    public class TestBase
    {
        protected User CreateGoodAddressUser()
        {
            return new User
            {
                Name = "Carol Lipskind",
                Address = new Address
                {
                    StreetAddress = "“Level 3,! 51_Pitt Street",
                    Suburb = "Sydney,",
                    State = "NSW 2000"
                }
            };
        }

        protected User CreateCorruptedAddressUser()
        {
            return new User
            {
                Name = "carol  lipskind",
                Address = new Address
                {
                    StreetAddress = "“Level 3,! 51_Pitt Street",
                    Suburb = "Sydney",
                    State = "NSW-2000"
                }
            };
        }
    }
}

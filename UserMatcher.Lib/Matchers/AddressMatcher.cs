using System;

namespace UserMatcher.Lib.Matchers
{
    public class AddressMatcher : BasicMatcher
    {
        public AddressMatcher(IUserMatcher decoratedMatcher = null)
            : base(decoratedMatcher) {  }

        public override bool IsMatch(User newUser, User existingUser)
        {
            if (base.IsMatch(newUser, existingUser))
                return true;

            if (newUser.Name != null && existingUser.Name != null && 
                existingUser.Name.ToTitleCase() == newUser.Name.ToTitleCase() && 
                newUser.Address != null && existingUser.Address != null)
            {
                return AddressMatch(newUser.Address, existingUser.Address);
            }
            return false;
        }

        private static bool AddressMatch(Address a1, Address a2)
        {
            return a1.State.RemoveNoise() == a2.State.RemoveNoise() &&
                a1.Suburb.RemoveNoise() == a2.Suburb.RemoveNoise() &&
                a1.StreetAddress.RemoveNoise() == a2.StreetAddress.RemoveNoise();
        }
    }
}

using System;

namespace UserMatcher.Lib
{
    public class BasicMatcher : IUserMatcher
    {
        private readonly IUserMatcher _decoratedMatcher;

        public BasicMatcher(IUserMatcher decoratedMatcher = null)
        {
            _decoratedMatcher = decoratedMatcher;
        }

        public virtual bool IsMatch(User newUser, User existingUser)
        {
            // A Null user equals null user (just in case ... )
            if (newUser == null || existingUser == null)
                return newUser == null && existingUser == null;

            if (_decoratedMatcher != null && _decoratedMatcher.IsMatch(newUser, existingUser))
                return true;

            return false;
        }
    }
}

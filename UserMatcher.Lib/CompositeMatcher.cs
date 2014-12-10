using System;
using System.Linq;
using System.Collections.Generic;

namespace UserMatcher.Lib
{
    public class CompositeMatcher : IUserMatcher
    {
        private readonly IEnumerable<IUserMatcher> _matchers;

        public CompositeMatcher(params IUserMatcher[] matchers)
        {
            _matchers = matchers.Where(m => m != null);
        }

        public bool IsMatch(User newUser, User existingUser)
        {
            return _matchers.All(m => m.IsMatch(newUser, existingUser));
        }
    }
}

using System;

namespace UserMatcher.Lib
{
    public interface IUserMatcher
    {
        bool IsMatch(User newUser, User existingUser);
    }
}

using System;

namespace UserMatcher.Lib.Matchers
{
    public class ReferralCodeMatcher : BasicMatcher
    {
        public ReferralCodeMatcher(IUserMatcher decorated = null) : base(decorated) {  }

        public override bool IsMatch(User newUser, User existingUser)
        {
            const int PatternLength = 3;

            if (base.IsMatch(newUser, existingUser))
                return true;

            var code1 = newUser.ReferralCode;
            var code2 = existingUser.ReferralCode;

            // Null case:
            if (code1 == null || code2 == null)
                return code1 == null && code2 == null;

            if (code1.Length != code2.Length)
                return false;

            int i = 0;
            for (; i < code1.Length - PatternLength; i++)
            {
                var substring1 = code1.Substring(i, PatternLength).ToLower();
                var substring2 = code2.Substring(i, PatternLength).ToLower();
                if (substring1 != substring2)
                {
                    // check for reversal:
                    var j = 0;
                    for (; j < PatternLength && substring1[j] == substring2[j]; j++);
                    if (i + j >= code1.Length || code1.Substring(i + j, PatternLength) != code2.Substring(i + j, PatternLength).ReverseString())
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

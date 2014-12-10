using System;

namespace UserMatcher.Lib.Matchers
{
    public class GeographicalDistanceMatcher : BasicMatcher
    {
        public GeographicalDistanceMatcher(IUserMatcher decoratedMatcher = null) 
            : base(decoratedMatcher) {  }

        public override bool IsMatch(User newUser, User existingUser)
        {
            if (base.IsMatch(newUser, existingUser))
                return true;

            if (newUser.Address != null && existingUser.Address != null)
            {
                //
                // http://en.wikipedia.org/wiki/Geographical_distance:
                //
                const double EarthRadius = 6371.009;
                const double PermittedDifference = 0.5;

                // radians conversion:
                var dLatitude  = Convert.ToDouble(newUser.Address.Latitude - existingUser.Address.Latitude) * Math.PI / 180;
                var dLongitude = Convert.ToDouble(newUser.Address.Longitude - existingUser.Address.Longitude) * Math.PI / 180;
                var avgLatitude = Convert.ToDouble(newUser.Address.Latitude + existingUser.Address.Latitude) * Math.PI / 360;

                return (EarthRadius * Math.Sqrt(Math.Pow(dLatitude, 2) + 
                    Math.Pow(Math.Cos(avgLatitude) * dLongitude, 2))) <= PermittedDifference;
            }
            return false;
        }
    }
}

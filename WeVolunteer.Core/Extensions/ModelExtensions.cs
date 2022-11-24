using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WeVolunteer.Core.Models.Cause;

namespace WeVolunteer.Core.Extensions
{
    public static class ModelExtensions
    {
        public static string GetInformation(this ICauseModel cause)
        {
            return cause.Name.Replace(" ", "-") + "_" + GetAddress(cause.Place);
        }

        private static string GetAddress(string place)
        {
            place = string.Join("-", place.Split(", ").Take(2));
            return Regex.Replace(place, @"[^a-zA-Z0-9\-]", string.Empty);
        }
    }
}

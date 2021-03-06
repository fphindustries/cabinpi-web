﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabinPi.Web.Models.DarkSky
{

    /// <summary>
    /// Extensions for the <see cref="long"/> type.
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Convert the UNIX timestamp to a <see cref="DateTimeOffset"/> for the given IANA <paramref name="timezone"/>.
        /// </summary>
        /// <param name="time">A UNIX timestamp.</param>
        /// <param name="timezone">An IANA timezone string.</param>
        /// <returns>A DateTimeOffset representing the moment in time.</returns>
        public static DateTime ToDateTimeFromUnixTimestamp(this long time, string timezone)
        {
            var dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(time);
            return dateTimeOffset.DateTime.ToLocalTime();
            //var tzi = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
            //return TimeZoneInfo.ConvertTime(dateTimeOffset.DateTime, tzi);
        }
    }
}

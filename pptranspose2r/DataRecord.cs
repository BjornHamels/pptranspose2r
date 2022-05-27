using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace pptranspose2r
{
    /// <summary>
    /// The data record that is repeated horizontally.
    /// </summary>
    public record DataRecord(string Date,
                             int Sitting0_30,
                             int Sitting30_60,
                             int Sitting60plus,
                             decimal WakingWearTime,
                             decimal SittingTime,
                             decimal StandingTime,
                             decimal TotalSteppingTime,
                             decimal LightSteppingTime,
                             decimal MVPAsteppingTime,
                             int NumberOfSittingBouts,
                             int NumberOfSteps,
                             decimal Sitting0_30_t,
                             decimal Sitting30_60_t,
                             decimal Sitting60plus_t) : IComparable<DataRecord>
    {
        /// <summary>
        /// For parsing the Date field (string).
        /// </summary>
        private static string DatePattern = @"([0-9]{1,2})-([0-9]{1,2})-([0-9]{4})";


        /// <summary>
        /// Returns a true DateOnly object of this records Date field.
        /// </summary>
        /// <returns>DateOnly of this record.</returns>
        public DateOnly GetDateOnly()
        {
            string datePart = Date.Substring(3);
            Match match = Regex.Match(Date, DatePattern);
            int day = int.Parse(match.Groups[1].Value);
            int month = int.Parse(match.Groups[2].Value);
            int year = int.Parse(match.Groups[3].Value);
            return new(year, month, day);
        }

        /// <summary>
        /// For sorting the list of data.
        /// </summary>
        /// <param name="other">The other record to compare to.</param>
        /// <returns>DateOnly.CompareTo()</returns>
        public int CompareTo(DataRecord? other)
        {
            return GetDateOnly().CompareTo(other.GetDateOnly());
        }
    }
}

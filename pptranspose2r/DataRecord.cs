using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace pptranspose2r
{
    /// <summary>
    /// The data record that is repeated horizontally by the PP tool.
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
        /// Constructor used when reading the strings unparsed from file.
        /// </summary>
        public DataRecord(string date,
                          string sitting0_30,
                          string sitting30_60,
                          string sitting60plus,
                          string wakingWearTime,
                          string sittingTime,
                          string standingTime,
                          string totalSteppingTime,
                          string lightSteppingTime,
                          string mVPAsteppingTime,
                          string numberOfSittingBouts,
                          string numberOfSteps,
                          string sitting0_30_t,
                          string sitting30_60_t,
                          string sitting60plus_t) : this(date,
                                                         Convert.ToInt32(sitting0_30),
                                                         Convert.ToInt32(sitting30_60),
                                                         Convert.ToInt32(sitting60plus),
                                                         Convert.ToDecimal(wakingWearTime),
                                                         Convert.ToDecimal(sittingTime),
                                                         Convert.ToDecimal(standingTime),
                                                         Convert.ToDecimal(totalSteppingTime),
                                                         Convert.ToDecimal(lightSteppingTime),
                                                         Convert.ToDecimal(mVPAsteppingTime),
                                                         Convert.ToInt32(numberOfSittingBouts),
                                                         Convert.ToInt32(numberOfSteps),
                                                         Convert.ToDecimal(sitting0_30_t),
                                                         Convert.ToDecimal(sitting30_60_t),
                                                         Convert.ToDecimal(sitting60plus_t))

        {

        }


        /// <summary>
        /// For parsing the Date field (string).
        /// </summary>
        private static string DatePattern = @"([0-9]{1,2})-([0-9]{1,2})-([0-9]{4})";

        /// <summary>
        /// The header texts.
        /// </summary>
        private readonly string[] DataHeaders = new string[] {"Date",
                                                              "Sitting0_30",
                                                              "Sitting30_60",
                                                              "Sitting60+",
                                                              "Waking wear time",
                                                              "Sitting time",
                                                              "Standing time",
                                                              "Total stepping time",
                                                              "Light stepping time",
                                                              "MVPA stepping time",
                                                              "Number of sitting bouts",
                                                              "Number of steps",
                                                              "Sitting0_30_t",
                                                              "Sitting30_60_t",
                                                              "Sitting60+_t"};

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

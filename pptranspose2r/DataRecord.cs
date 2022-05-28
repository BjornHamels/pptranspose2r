using System;
using System.Collections.Generic;
using System.Globalization;
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
                             decimal Sitting0_30,
                             decimal Sitting30_60,
                             decimal Sitting60plus,
                             decimal WakingWearTime,
                             decimal SittingTime,
                             decimal StandingTime,
                             decimal TotalSteppingTime,
                             decimal LightSteppingTime,
                             decimal MVPAsteppingTime,
                             decimal NumberOfSittingBouts,
                             decimal NumberOfSteps,
                             decimal Sitting0_30_t,
                             decimal Sitting30_60_t,
                             decimal Sitting60plus_t) : IComparable<DataRecord>
    {

        /// <summary>
        /// Hints the conversion to use the non native .-decimal seperator.
        /// </summary>
        private static NumberFormatInfo nfiDecimalDot = NumberFormatInfo.InvariantInfo;

        /// <summary>
        /// Constructor used when reading the strings unparsed from file.
        /// </summary>
        public DataRecord(IEnumerable<HeaderData> hd) :
            this(hd.ElementAt(0).Data,
                 Convert.ToDecimal(hd.ElementAt(1).Data, nfiDecimalDot),
                 Convert.ToDecimal(hd.ElementAt(2).Data, nfiDecimalDot),
                 Convert.ToDecimal(hd.ElementAt(3).Data, nfiDecimalDot),
                 Convert.ToDecimal(hd.ElementAt(4).Data, nfiDecimalDot),
                 Convert.ToDecimal(hd.ElementAt(5).Data, nfiDecimalDot),
                 Convert.ToDecimal(hd.ElementAt(6).Data, nfiDecimalDot),
                 Convert.ToDecimal(hd.ElementAt(7).Data, nfiDecimalDot),
                 Convert.ToDecimal(hd.ElementAt(8).Data, nfiDecimalDot),
                 Convert.ToDecimal(hd.ElementAt(9).Data, nfiDecimalDot),
                 Convert.ToDecimal(hd.ElementAt(10).Data, nfiDecimalDot),
                 Convert.ToDecimal(hd.ElementAt(11).Data, nfiDecimalDot),
                 Convert.ToDecimal(hd.ElementAt(12).Data, nfiDecimalDot),
                 Convert.ToDecimal(hd.ElementAt(13).Data, nfiDecimalDot),
                 Convert.ToDecimal(hd.ElementAt(14).Data, nfiDecimalDot))
        {
            for (int i = 0; i < 15; i++)
                if (hd.ElementAt(i).Header != DataHeaders[i])
                    throw new ArgumentException($"DataRecord header({hd.ElementAt(i)}) does not match expected ({DataHeaders[i]}).");
        }

        /// <summary>
        /// For parsing the Date field (string).
        /// </summary>
        private static string DatePattern = @"([0-9]{1,2})-([0-9]{1,2})-([0-9]{4})";

        /// <summary>
        /// The header texts we are expecting.
        /// </summary>
        public static string[] DataHeaders = new string[] {"Date",
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

        /// <summary>
        /// Returns a nicely formatted horizontal csv line R can easly read.
        /// </summary>
        /// <param name="ParticipantID">The involved participant.</param>
        /// <returns>The csv line that is nicely formatted.</returns>
        public string GetRLine(string ParticipantID)
        {
            NumberFormatInfo dot = new NumberFormatInfo();
            dot.NumberDecimalSeparator = ".";

            return $"{ParticipantID}, {GetDateOnly().ToString("yyyy-MM-dd")}, {Sitting0_30.ToString(nfiDecimalDot)}, " +
                   $"{Sitting30_60.ToString(nfiDecimalDot)}, {Sitting60plus.ToString(nfiDecimalDot)}, " +
                   $"{WakingWearTime.ToString(nfiDecimalDot)}, {SittingTime.ToString(nfiDecimalDot)}, " +
                   $"{StandingTime.ToString(nfiDecimalDot)}, {TotalSteppingTime.ToString(nfiDecimalDot)}, " +
                   $"{LightSteppingTime.ToString(nfiDecimalDot)}, {MVPAsteppingTime.ToString(nfiDecimalDot)}, " +
                   $"{NumberOfSittingBouts.ToString(nfiDecimalDot)}, {NumberOfSteps.ToString(nfiDecimalDot)}, " +
                   $"{Sitting0_30_t.ToString(nfiDecimalDot)}, {Sitting30_60_t.ToString(nfiDecimalDot)}, " +
                   $"{Sitting60plus_t.ToString(nfiDecimalDot)}";
        }

    }

}

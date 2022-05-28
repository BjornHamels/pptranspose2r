using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pptranspose2r
{
    /// <summary>
    /// At the end of the horizontal line PP adds a summary/average record defined below.
    /// Eventhough the record in the test data shows interger rounding for some fields,
    /// decimals are chosen to store the numbers due to their accuracy.
    /// </summary>
    public record DataAverageRecord(decimal WakingWearTime_Avg,
                                    decimal SittingTime_Avg,
                                    decimal StandingTime_Avg,
                                    decimal TotalSteppingTime_Avg,
                                    decimal LightSteppingTime_Avg,
                                    decimal MVPAsteppingTime_Avg,
                                    decimal NumberOfSittingBouts_Avg,
                                    decimal NumberOfSteps_Avg,
                                    decimal Sitting0_30_Avg,
                                    decimal Sitting30_60_Avg,
                                    decimal Sitting60plus_Avg,
                                    decimal Sitting0_30_t_Avg,
                                    decimal Sitting30_60_t_Avg,
                                    decimal Sitting60plus_t_Avg,
                                    decimal WeartimeDays)
    {
        /// <summary>
        /// Hints the conversion to use the non native .-decimal seperator.
        /// </summary>
        private static NumberFormatInfo nfiDecimalDot = NumberFormatInfo.InvariantInfo;

        /// <summary>
        /// Constructor used when reading the strings unparsed from file.
        /// </summary>
        public DataAverageRecord(IEnumerable<HeaderData> hd) :
            this(Convert.ToDecimal(hd.ElementAt(0).Data, nfiDecimalDot),
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
                if (hd.ElementAt(i).Header != DataAverageHeaders[i])
                    throw new ArgumentException($"DataAverageRecord header({hd.ElementAt(i)}) does not match expected ({DataAverageHeaders[i]}).");
        }

        /// <summary>
        /// The header texts we are expecting.
        /// </summary>
        public static string[] DataAverageHeaders = new string[] {"Waking wear time_Avg",
                                                                  "Sitting time_Avg",
                                                                  "Standing time_Avg",
                                                                  "Total stepping time_Avg",
                                                                  "Light stepping time_Avg",
                                                                  "MVPA stepping time_Avg",
                                                                  "Number of sitting bouts_Avg",
                                                                  "Number of steps_Avg",
                                                                  "Sitting0_30_Avg",
                                                                  "Sitting30_60_Avg",
                                                                  "Sitting60+_Avg",
                                                                  "Sitting0_30_t_Avg",
                                                                  "Sitting30_60_t_Avg",
                                                                  "Sitting60+_t_Avg",
                                                                  "Weartime days"};


        /// <summary>
        /// Returns this average record as a horizontal csv line.
        /// </summary>
        /// <param name="ParticipantID">The involved participant.</param>
        /// <returns>The csv line of this average record.</returns>
        public string GetRLine(string ParticipantID)
        {
            return $"{ParticipantID}, {WakingWearTime_Avg.ToString(nfiDecimalDot)}, " +
                   $"{SittingTime_Avg.ToString(nfiDecimalDot)}, {StandingTime_Avg.ToString(nfiDecimalDot)}, " +
                   $"{TotalSteppingTime_Avg.ToString(nfiDecimalDot)}, {LightSteppingTime_Avg.ToString(nfiDecimalDot)}, " +
                   $"{MVPAsteppingTime_Avg.ToString(nfiDecimalDot)}, {NumberOfSittingBouts_Avg.ToString(nfiDecimalDot)}, " +
                   $"{NumberOfSteps_Avg.ToString(nfiDecimalDot)}, {Sitting0_30_Avg.ToString(nfiDecimalDot)}, " +
                   $"{Sitting30_60_Avg.ToString(nfiDecimalDot)}, {Sitting60plus_Avg.ToString(nfiDecimalDot)}, " +
                   $"{Sitting0_30_t_Avg.ToString(nfiDecimalDot)}, {Sitting30_60_t_Avg.ToString(nfiDecimalDot)}, " +
                   $"{Sitting60plus_t_Avg.ToString(nfiDecimalDot)}, {WeartimeDays.ToString(nfiDecimalDot)}";
        }

    }

}

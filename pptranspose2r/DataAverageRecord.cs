using System;
using System.Collections.Generic;
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
        /// Constructor used when reading the strings unparsed from file.
        /// </summary>
        public DataAverageRecord(string wakingWearTime_Avg,
                                 string sittingTime_Avg,
                                 string standingTime_Avg,
                                 string totalSteppingTime_Avg,
                                 string lightSteppingTime_Avg,
                                 string mVPAsteppingTime_Avg,
                                 string numberOfSittingBouts_Avg,
                                 string numberOfSteps_Avg,
                                 string sitting0_30_Avg,
                                 string sitting30_60_Avg,
                                 string sitting60plus_Avg,
                                 string sitting0_30_t_Avg,
                                 string sitting30_60_t_Avg,
                                 string sitting60plus_t_Avg,
                                 string weartimeDays) : this(Convert.ToDecimal(wakingWearTime_Avg),
                                                             Convert.ToDecimal(sittingTime_Avg),
                                                             Convert.ToDecimal(standingTime_Avg),
                                                             Convert.ToDecimal(totalSteppingTime_Avg),
                                                             Convert.ToDecimal(lightSteppingTime_Avg),
                                                             Convert.ToDecimal(mVPAsteppingTime_Avg),
                                                             Convert.ToDecimal(numberOfSittingBouts_Avg),
                                                             Convert.ToDecimal(numberOfSteps_Avg),
                                                             Convert.ToDecimal(sitting0_30_Avg),
                                                             Convert.ToDecimal(sitting30_60_Avg),
                                                             Convert.ToDecimal(sitting60plus_Avg),
                                                             Convert.ToDecimal(sitting0_30_t_Avg),
                                                             Convert.ToDecimal(sitting30_60_t_Avg),
                                                             Convert.ToDecimal(sitting60plus_t_Avg),
                                                             Convert.ToDecimal(weartimeDays))
        {

        }
    }

}

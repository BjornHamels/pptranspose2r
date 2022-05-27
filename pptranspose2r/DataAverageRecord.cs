using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pptranspose2r
{
    /// <summary>
    /// At the end of the horizontal line PP adds a summary/average record defined below.
    /// </summary>
    public record DataAverageRecord(decimal WakingWearTime_Avg,
                                    decimal SittingTime_Avg,
                                    decimal StandingTime_Avg,
                                    decimal TotalSteppingTime_Avg,
                                    decimal LightSteppingTime_Avg,
                                    decimal MVPAsteppingTime_Avg,
                                    int NumberOfSittingBouts_Avg,
                                    int NumberOfSteps_Avg,
                                    int Sitting0_30_Avg,
                                    int Sitting30_60_Avg,
                                    int Sitting60plus_Avg,
                                    decimal Sitting0_30_t_Avg,
                                    decimal Sitting30_60_t_Avg,
                                    decimal Sitting60plus_t_Avg,
                                    decimal WeartimeDays)
    {

    }
}

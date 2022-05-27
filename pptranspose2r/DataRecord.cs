using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                             decimal Sitting60plus_t)
    {
    }
}

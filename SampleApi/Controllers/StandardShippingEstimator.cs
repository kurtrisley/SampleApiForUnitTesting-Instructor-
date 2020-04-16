using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.Controllers
{
    public class StandardShippingEstimator : IEstimateShipping
    {
        ISystemTime SystemTime;

        public StandardShippingEstimator(ISystemTime systemTime)
        {
            SystemTime = systemTime;
        }

        DateTime IEstimateShipping.GetEstimatedShipDate()
        {
            return SystemTime.GetCurrent().Hour <= 17 ?
                SystemTime.GetCurrent().Date :
                SystemTime.GetCurrent().AddDays(1).Date ;
        }
    }
}

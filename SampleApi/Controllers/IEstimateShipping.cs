using System;

namespace SampleApi.Controllers
{
    public interface IEstimateShipping
    {
        DateTime GetEstimatedShipDate();
    }
}
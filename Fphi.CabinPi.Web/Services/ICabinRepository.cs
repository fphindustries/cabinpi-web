using Fphi.CabinPi.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fphi.CabinPi.Web.Services
{
    public interface ICabinRepository
    {
        void AddSensorData(ReadingAggregate data);
    }
}

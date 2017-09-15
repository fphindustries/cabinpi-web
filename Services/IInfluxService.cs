using System.Threading.Tasks;
using Fphi.CabinPi.Web.Models;

namespace Fphi.CabinPi.Web.Services
{
    public interface IInfluxService
    {
        Task<SensorData> GetSensorData();
    }
}
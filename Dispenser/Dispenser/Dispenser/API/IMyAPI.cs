using System;
using System.Threading.Tasks;
using Dispenser.Models;
using Refit;

namespace Dispenser.API
{
    public interface IMyAPI
    {
        #region Post

        [Post("/api/Login")]
        Task<string> Login([Body] User value);

        [Post("/api/Devices")]
        Task<bool> PostDevice([Body] Device value);

        [Post("/api/Filter")]
        Task<bool> ResetFilter([Body] ResetFilter value);

        #endregion Post

        #region Get

        [Get("/api/Devices/{id}")]
        Task<Device> GetDevice(int id);

        #endregion Get
    }
}

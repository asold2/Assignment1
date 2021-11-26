using System.Collections.Generic;
using System.Threading.Tasks;
using AssignmentWebAPI.Model;

namespace AssignmentWebAPI.Data
{
    public interface IAdultsData
    {
        Task<IList<Adult>> GetAdults();
        Task addAdult(Adult adult);
        Task<Adult> addAdultTwo(Adult adult);
        Task RemoveAdult(int id);
        Task<Adult> getAdult(int id);

        // Task<Job> getAdultsJob(int id);
    }
}
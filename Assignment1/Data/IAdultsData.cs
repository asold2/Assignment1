using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assignment1.Model;

namespace Assignment1.Data
{
    public interface IAdultsData
    {
        Task<IList<Adult>> GetAdultsAsync();
        Task addAdultAsync(Adult adult);
        Task RemoveAdultAsync(int id);
        Task<Adult> getAdultAsync(int id);
    }
}
using System.Collections.Generic;
using AssignmentWebAPI.Model;

namespace AssignmentWebAPI.Data
{
    public interface IAdultsData
    {
        IList<Adult> GetAdults();
        void addAdult(Adult adult);
        Adult addAdultTwo(Adult adult);
        void RemoveAdult(int id);
        Adult getAdult(int id);
    }
}
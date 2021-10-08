using System.Collections;
using System.Collections.Generic;
using Assignment1.Model;

namespace Assignment1.Data
{
    public interface IAdultsData
    {
        IList<Adult> GetAdults();
        void addAdult(Adult adult);
        void RemoveAdult(int id);
        Adult getAdult(int id);
    }
}
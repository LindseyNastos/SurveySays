using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICampusServices
    {
        IList<Campus> GetAllCampuses();
    }
}

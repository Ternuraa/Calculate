using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate.Storage
{
    public interface IStorage
    {
        Task Save(List<double> list);
        Task<List<double>> Load();
    }

}

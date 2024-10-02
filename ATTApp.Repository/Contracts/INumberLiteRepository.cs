using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATTApp.Data.Sqllite.Models;

namespace ATTApp.Repository.Contracts
{
    public interface INumberLiteRepository
    {
        bool Add(ConcurrentBag<int> listValues);

        List<Number> GetData();
    }
}

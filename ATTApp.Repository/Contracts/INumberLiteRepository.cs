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
        Task<bool> Add(List<List<Number>> lst);
        Task<List<Number>> GetData();
        List<List<Number>> ConvertToBatches(ConcurrentBag<int> list, int batchSize);
        Task<bool> Delete();
    }
}

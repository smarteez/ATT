using ATTApp.Domin;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATTApp.UseCase
{
    public  class SortingUseCase
    {
        public DisplayDTO SortAndDisplayResults(ConcurrentBag<int> globalVariable)
        {
            var sortedList = globalVariable.OrderBy(x => x).ToList();
            int totalCount = globalVariable.Count;
            int oddCount = sortedList.Count(x => x % 2 != 0);
            int evenCount = totalCount - oddCount;

            return new DisplayDTO
            {
                TotalCount = totalCount,
                OldCount = oddCount,
                EventCount = oddCount,
                list = globalVariable
            };
        }
    }
}

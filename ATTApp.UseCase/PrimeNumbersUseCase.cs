using ATTApp.Shared;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATTApp.UseCase
{
    public class PrimeNumbersUseCase
    {
        public IsPrime IsPrime { get; set; }
        public PrimeNumbersUseCase(IsPrime isPrime)
        {
            IsPrime = isPrime;
        } 

        public void GeneratePrimeNumbers(ConcurrentBag<int> globalVariable, int limit)
        {
            int number = 2;
            while (globalVariable.Count < limit)
            {
                if (IsPrime.Check(number))
                {
                    globalVariable.Add(-number);
                }
                number++;
            }
        }
    }
}

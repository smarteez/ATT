using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATTApp.UseCase
{
    public class OldNumbersUseCase
    {
        private static Random random = new Random();

        public void GenerateOddNumbers(ConcurrentBag<int> globalVariable, int limit)
        {
            while (globalVariable.Count < limit)
            {
                int number = random.Next(1, int.MaxValue);
                if (number % 2 != 0)
                {
                    globalVariable.Add(number);
                }
            }
        }
    }
}

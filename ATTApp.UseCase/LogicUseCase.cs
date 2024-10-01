using ATTApp.Domin;
using ATTApp.Repository.Contracts;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ATTApp.UseCase
{
    public  class LogicUseCase
    {
        public OldNumbersUseCase OldNumbersUseCase { get; set; }
        public PrimeNumbersUseCase PrimeNumbersUseCase { get; set; }
        public EvenNumbersUseCase EvenNumbersUseCase { get; set; }
        public SortingUseCase SortingUseCase { get; set; }

        private static ConcurrentBag<int> globalVariable = new ConcurrentBag<int>();

        public LogicUseCase(OldNumbersUseCase oldNumbersUseCase, PrimeNumbersUseCase primeNumbersUseCase, EvenNumbersUseCase evenNumbersUseCase, SortingUseCase sortingUseCase)
        {
            OldNumbersUseCase = oldNumbersUseCase;
            PrimeNumbersUseCase = primeNumbersUseCase;
            EvenNumbersUseCase = evenNumbersUseCase;
            SortingUseCase = sortingUseCase;
        }

        public DisplayDTO Start()
        {


            Task oddNumberTask = Task.Run(() => OldNumbersUseCase.Execute(globalVariable, 2500000));
            Task primeNumberTask = Task.Run(() => PrimeNumbersUseCase.Execute(globalVariable, 2500000));

            Task.WaitAll(oddNumberTask, primeNumberTask);

            Task evenNumberTask = Task.Run(() => EvenNumbersUseCase.Execute(globalVariable, 10000000));
            evenNumberTask.Wait();
            return SortingUseCase.Execute(globalVariable);
        }


    }
}

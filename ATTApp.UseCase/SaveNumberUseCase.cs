using ATTApp.Repository.Contracts;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATTApp.UseCase
{
    public  class SaveNumberUseCase
    {


        public INumberRepository INumberRepository {  get; set; }
        public SaveNumberUseCase(INumberRepository iNumberRepository)
        {
            INumberRepository = iNumberRepository;
        }

        public bool Execute(ConcurrentBag<int> globalVariable)
        {
            return INumberRepository.Add(globalVariable);
        }
    }
}

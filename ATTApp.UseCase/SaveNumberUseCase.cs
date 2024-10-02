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
        public INumberLiteRepository INumberLiteRepository { get; set; }    
        public SaveNumberUseCase(INumberRepository iNumberRepository, INumberLiteRepository iNumberLiteRepository) : this(iNumberRepository)
        {
            INumberLiteRepository = iNumberLiteRepository;
        }

        public bool ExecuteSql(ConcurrentBag<int> globalVariable)
        {
            return INumberRepository.Add(globalVariable);
        }

        public bool ExecuteSqlLite(ConcurrentBag<int> globalVariable)
        {
            return INumberLiteRepository.Add(globalVariable);
        }
    }
}

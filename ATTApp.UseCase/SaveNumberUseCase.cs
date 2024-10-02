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
        public SaveNumberUseCase(INumberRepository iNumberRepository, INumberLiteRepository iNumberLiteRepository)
        {
            INumberRepository = iNumberRepository;
            INumberLiteRepository = iNumberLiteRepository;
        }
        public bool ExecuteSql(ConcurrentBag<int> globalVariable)
        {
            return INumberRepository.Add(globalVariable);
        }

        public async Task<bool> ExecuteSqlLite(ConcurrentBag<int> globalVariable)
        {
            await INumberLiteRepository.Delete();
            var lst = INumberLiteRepository.ConvertToBatches(globalVariable, 1000000);
            return await INumberLiteRepository.Add(lst);
        }
    }
}

using ATTApp.Repository.Contracts;
using ATTApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ATTApp.UseCase
{
    public  class GetNumberBinaryUseCase
    {


        public INumberRepository INumberRepository { get; set; }

        public INumberLiteRepository INumberLiteRepository { get; set; }
        public ListToBinary ListToBinary { get; set; }

        public GetNumberBinaryUseCase(INumberRepository iNumberRepository, ListToBinary listToBinary, INumberLiteRepository iNumberLiteRepository)
        {
            INumberRepository = iNumberRepository;
            ListToBinary = listToBinary;
            INumberLiteRepository = iNumberLiteRepository;
        }
        public string ExecuteSql()
        {
            var lst = INumberRepository.GetData();
            var bin =  ListToBinary.Convert(lst).ToString();
            var byteArray = Encoding.UTF8.GetBytes(bin);
            return Convert.ToBase64String(byteArray);

        }

        public async Task<string> ExecuteSqlLite()
        {
            var lst = await INumberLiteRepository.GetData();
            var bin = ListToBinary.Convert(lst).ToString();
            var byteArray = Encoding.UTF8.GetBytes(bin);
            return Convert.ToBase64String(byteArray);

        }
    }
}

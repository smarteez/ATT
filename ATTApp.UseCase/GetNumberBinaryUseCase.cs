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
        public ListToBinary ListToBinary { get; set; }

        public GetNumberBinaryUseCase(INumberRepository iNumberRepository, ListToBinary listToBinary)
        {
            INumberRepository = iNumberRepository;
            ListToBinary = listToBinary;
        }
        public byte[] Execute()
        {
            var lst = INumberRepository.GetData();
            return ListToBinary.Convert(lst);

        }
    }
}

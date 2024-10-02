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
    public class GetNumberXMLUseCase
    {

        public INumberRepository INumberRepository { get; set; }
        public INumberLiteRepository INumberLiteRepository { get; set; }
        public ListToXml ListToXml { get; set; }


        public GetNumberXMLUseCase(INumberRepository iNumberRepository, INumberLiteRepository iNumberLiteRepository, ListToXml listToXml)
        {
            INumberRepository = iNumberRepository;
            INumberLiteRepository = iNumberLiteRepository;
            ListToXml = listToXml;
        }

        public string ExecuteSql()
        {
            var lst = INumberRepository.GetData();
            var xml =  ListToXml.Convert(lst).ToString();
            var byteArray = Encoding.UTF8.GetBytes(xml);
            return Convert.ToBase64String(byteArray);
        }

        public string ExecuteSqlLite()
        {
            var lst = INumberLiteRepository.GetData();
            var xml = ListToXml.Convert(lst).ToString();
            var byteArray = Encoding.UTF8.GetBytes(xml);
            return Convert.ToBase64String(byteArray);
        }
    }
}

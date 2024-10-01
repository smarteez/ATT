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
        public ListToXml ListToXml { get; set; }

        public GetNumberXMLUseCase(INumberRepository iNumberRepository, ListToXml listToXml)
        {
            INumberRepository = iNumberRepository;
            ListToXml = listToXml;
        }

        public XDocument Execute()
        {
            var lst = INumberRepository.GetData();
            return ListToXml.Convert(lst);

        }
    }
}

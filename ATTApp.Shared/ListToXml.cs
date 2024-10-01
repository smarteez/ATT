using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ATTApp.Shared
{
    public class ListToXml
    {
        public static XDocument Convert<T>(List<T> items)
        {
            XElement root = new XElement(typeof(T).Name + "s");

            foreach (var item in items)
            {
                XElement element = new XElement(typeof(T).Name);
                foreach (var prop in typeof(T).GetProperties())
                {
                    element.Add(new XElement(prop.Name, prop.GetValue(item, null)));
                }
                root.Add(element);
            }

            return new XDocument(root);
        }
    }
}

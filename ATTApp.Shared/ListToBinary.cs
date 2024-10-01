using MessagePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ATTApp.Shared
{
    public  class ListToBinary
    {
        public static byte[] Convert<T>(T obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            return MessagePackSerializer.Serialize(obj);
        }
    }
}

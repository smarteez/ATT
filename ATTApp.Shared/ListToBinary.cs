using MessagePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ATTApp.Shared
{
    public  class ListToBinary
    {
        public static byte[] Convert<T>(List<T> list)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            return JsonSerializer.SerializeToUtf8Bytes(list);
        }
    }
}

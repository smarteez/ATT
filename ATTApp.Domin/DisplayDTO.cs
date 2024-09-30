using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATTApp.Domin
{
    public class DisplayDTO
    {
        public int TotalCount { get; set; }
        public int OldCount { get; set; }
        public int EventCount { get; set; }

        public ConcurrentBag<int> list { get; set; }
    }
}

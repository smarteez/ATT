﻿using ATTApp.Data.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATTApp.Repository.Contracts
{
    public  interface INumberRepository
    {
        bool Add(ConcurrentBag<int> listValues);

        List<Number> GetData();
    }
}

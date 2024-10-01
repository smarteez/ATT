﻿using ATTApp.Data.Models;
using ATTApp.Repository.Contracts;
using ATTApp.Shared;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ATTApp.Repository.Modules
{
    public class NumberRepository : INumberRepository
    {
        public attContext context { get; set; }
        public IsPrime IsPrime { get; set; }

        public List<Number> numClass = new List<Number>();

        public NumberRepository(attContext context, IsPrime isPrime)
        {
            this.context = context;
            IsPrime = isPrime;
        }

        public bool Add(ConcurrentBag<int> list)
        {
            try
            {
                context.Numbers.AddRange(CreateObject(list));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public List<Number> GetData() 
        { 
            return context.Numbers.ToList();
        }

        private List<Number> CreateObject(ConcurrentBag<int> list)
        {
            foreach (var item in list)
            {
                bool isPrime = IsPrime.Check(Math.Abs(item));
                numClass.Add(
                    new Number
                    {
                        IsPrime = isPrime,
                        Value = item
                    }
                    );
            }

            return numClass;
        }


       
    }
}

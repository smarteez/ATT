using ATTApp.Data.Sqllite.Models;
using ATTApp.Repository.Contracts;
using ATTApp.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATTApp.Repository.Modules
{
    public  class NumberLiteRepository : INumberLiteRepository
    {
        public CCodeATTSqlLiteAttLitedbContext context { get; set; }
        public IsPrime IsPrime { get; set; }

        public List<Number> numClass = new List<Number>();

        public NumberLiteRepository(CCodeATTSqlLiteAttLitedbContext context, IsPrime isPrime)
        {
            this.context = context;
            IsPrime = isPrime;
        }

        public List<Number> GetData()
        {
            return context.Numbers.ToList();
        }

        public bool Add(ConcurrentBag<int> list)
        {
            try
            {
                context.Numbers.ExecuteDelete();
                context.SaveChanges();

                int batchSize = 10000;
                var batches = list
                    .Select((value, index) => new { value, index })
                    .GroupBy(x => x.index / batchSize)
                    .Select(g => g.Select(x => x.value).ToList())
                    .ToList();

                foreach (var batch in batches)
                {
                    var objects = CreateObject(batch);
                    context.Numbers.AddRangeAsync(objects);
                    context.SaveChangesAsync();
                }
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }



        private List<Number> CreateObject(List<int> list)
        {
            foreach (var item in list)
            {
                bool isPrime = IsPrime.Check(Math.Abs(item));
                numClass.Add(
                    new Number
                    {
                        IsPrime = isPrime ? 1:0,
                        Value = item
                    }
                    );
            }

            return numClass;
        }
    }
}

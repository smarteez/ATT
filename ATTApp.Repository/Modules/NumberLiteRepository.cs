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
        public class NumberLiteRepository : INumberLiteRepository
        {
            public CCodeATTSqlLiteAttLitedbContext context { get; set; }
            public IsPrime IsPrime { get; set; }

            public List<Number> numClass = new List<Number>();

            public NumberLiteRepository(CCodeATTSqlLiteAttLitedbContext context, IsPrime isPrime)
            {
                this.context = context;
                IsPrime = isPrime;
            }

            public async Task< List<Number>> GetData()
            {
                return await context.Numbers.ToListAsync();
            }

            public async Task<bool> Add(List<List<Number>> lst)
            {
                try
                {

                    // Initialize context once
                    var optionsBuilder = new DbContextOptionsBuilder<CCodeATTSqlLiteAttLitedbContext>();
                    optionsBuilder.UseSqlite("Data Source=C:\\Code\\ATT\\SqlLite\\AttLite.db");

                    using (var context = new CCodeATTSqlLiteAttLitedbContext(optionsBuilder.Options))
                    {
                        // Set PRAGMA settings once
                        await context.Database.ExecuteSqlRawAsync("PRAGMA journal_mode = OFF;");
                        await context.Database.ExecuteSqlRawAsync("PRAGMA synchronous = 0;");
                        await context.Database.ExecuteSqlRawAsync("PRAGMA cache_size = 1000000;");
                        await context.Database.ExecuteSqlRawAsync("PRAGMA locking_mode = EXCLUSIVE;");
                        await context.Database.ExecuteSqlRawAsync("PRAGMA temp_store = MEMORY;");

                        context.ChangeTracker.AutoDetectChangesEnabled = false;

                        foreach (var batch in lst)
                        {
                            await context.Database.BeginTransactionAsync();

                            await context.Numbers.AddRangeAsync(batch);

                            await context.SaveChangesAsync();
                            await context.Database.CommitTransactionAsync();
                        }
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    // Log the exception (optional)
                    return false;
                }
            }

            public List<List<Number>> ConvertToBatches(ConcurrentBag<int> list, int batchSize)
            {
                var batches = list
                    .Select((value, index) => new { value, index })
                    .GroupBy(x => x.index / batchSize)
                    .Select(g => g.Select(x => x.value).ToList())
                    .ToList();

                var result = new List<List<Number>>();
                foreach (var batch in batches)
                {
                    var numberObjects = CreateObject(batch);
                    result.Add(numberObjects);
                }

                return result;
            }

            public async Task<bool> Delete()
            {
                try
                {
                    var optionsBuilder = new DbContextOptionsBuilder<CCodeATTSqlLiteAttLitedbContext>();
                    optionsBuilder.UseSqlite("Data Source=C:\\Code\\ATT\\SqlLite\\AttLite.db");

                    using (var context = new CCodeATTSqlLiteAttLitedbContext(optionsBuilder.Options))
                    {
                        await context.Numbers.ExecuteDeleteAsync();
                        await context.SaveChangesAsync();
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
                            IsPrime = isPrime ? 1 : 0,
                            Value = item
                        }
                        );
                }

                return numClass;
            }
        }
    }

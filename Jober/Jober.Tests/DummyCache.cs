using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Jober.Tests
{
    public class DummyCache : IMemoryCache
    {
        private List<string> keys;
        public DummyCache(List<string> keys)
        {
            this.keys = keys;
        }

        public ICacheEntry CreateEntry(object key)
        {
            return null;
        }

        public void Dispose()
        {
            
        }

        public void Remove(object key)
        {
            
        }

        public bool TryGetValue(object key, out object value)
        {
            keys.Add((string)key);
            if ((string)key == "Jobs")
            {
                value = new List<Models.Job>();
            }
            else if ((string)key == "Cities")
            {
                value = new List<Models.City>();
            }
            else
            {
                throw new Exception("Wrong key");
            }

            return true;
        }
    }
}

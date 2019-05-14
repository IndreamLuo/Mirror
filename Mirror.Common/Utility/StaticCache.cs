using System;
using System.Collections.Generic;

namespace Mirror.Common.Utility
{
    public static class StaticCache
    {
        static Dictionary<string, dynamic> Cache = new Dictionary<string, dynamic>();

        public static T GetCacheOrInstance<T>(string key, Func<T> getInstance)
        {
            dynamic output;

            if (!Cache.TryGetValue(key, out output))
            {
                output = getInstance();
                Cache[key] = output;
            }

            return output;
        }

        public static void Clear(string key)
        {
            Cache.Remove(key);
        }
    }
}
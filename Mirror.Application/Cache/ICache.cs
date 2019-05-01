using System;

namespace Mirror.Application.Cache
{
    public interface ICache
    {
        T GetCacheOrInstance<T>(string key, Func<T> getInstance);
    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Mirror.Application.Cache;
using Mirror.Data.Entities;

namespace Mirror.Application.Service
{
    public class ServicesContainer
    {
        public ServicesContainer()
        {
            ServicesStorage = new Dictionary<string, Data.Entities.Service>();
            VendersStorage = new Dictionary<string, IDictionary<string, Vendor>>();
        }

        protected readonly IDictionary<string, Data.Entities.Service> ServicesStorage;
        protected readonly IDictionary<string, IDictionary<string, Vendor>> VendersStorage;

        public IEnumerable<Data.Entities.Service> Services => ServicesStorage.Values;

        public Data.Entities.Service this[string key]
        {
            get => ServicesStorage[key];
            set
            {
                IDictionary<string, Vendor> vendersDictionary;
                if (!VendersStorage.TryGetValue(key, out vendersDictionary))
                {
                    vendersDictionary = new Dictionary<string, Vendor>();
                    VendersStorage[key] = vendersDictionary;
                }

                ServicesStorage[key] = value;
            }
        }

        public void RemoveService(string key)
        {
            ServicesStorage.Remove(key);
        }

        public Vendor this[string serviceKey, string venderKey]
        {
            get => VendersStorage[serviceKey][venderKey];
            set
            {
                this[serviceKey].Vendors.Add(value);
                VendersStorage[serviceKey][venderKey] = value;
            }
        }

        public void RemoveVender(string serviceKey, string venderKey)
        {
            var vender = this[serviceKey, venderKey];

            this[serviceKey].Vendors.Remove(vender);
            VendersStorage[serviceKey].Remove(venderKey);
        }
    }
}
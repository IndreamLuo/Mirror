using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Mirror.Application.Cache;

namespace Mirror.Application.Service
{
    public class ServicesContainer
    {
        public ServicesContainer()
        {
            ServicesStorage = new Dictionary<string, Common.Model.Service>();
            VendersStorage = new Dictionary<string, IDictionary<string, Common.Model.Vendor>>();
        }

        protected readonly IDictionary<string, Common.Model.Service> ServicesStorage;
        protected readonly IDictionary<string, IDictionary<string, Common.Model.Vendor>> VendersStorage;

        public IEnumerable<Common.Model.Service> Services => ServicesStorage.Values;

        public Common.Model.Service this[string key]
        {
            get => ServicesStorage[key];
            set
            {
                IDictionary<string, Common.Model.Vendor> vendersDictionary;
                if (!VendersStorage.TryGetValue(key, out vendersDictionary))
                {
                    vendersDictionary = new Dictionary<string, Common.Model.Vendor>();
                    VendersStorage[key] = vendersDictionary;
                }

                ServicesStorage[key] = value;
            }
        }

        public void RemoveService(string key)
        {
            ServicesStorage.Remove(key);
        }

        public Common.Model.Vendor this[string serviceKey, string venderKey]
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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Mirror.Data.Entities;

namespace Mirror.Application.Service
{
    public static class SystemServices
    {
        public const string _available = "_available";
        
        public static ReadOnlyDictionary<string, Data.Entities.Service> All = new ReadOnlyDictionary<string, Data.Entities.Service>(new Dictionary<string, Data.Entities.Service>
        {
            {
                _available,
                new Data.Entities.Service
                {
                    Key = _available,
                    Name = "Mirror Available",
                    Description = "To check if current system available.",
                    Vendors = new []
                    {
                        new Vendor
                        {
                            Url = "-/System/Available"
                        }
                    }
                }
            }
        });
    }
}
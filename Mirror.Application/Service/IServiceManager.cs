namespace Mirror.Application.Service
{
    public interface IServiceManager
    {
        ServicesContainer Container { get; }

        void Initialize();

        void Persist(string key);

        void Persist(string serviceKey, string venderKey);
    }
}
namespace Mirror.UnitTest
{
    public interface IInstanceTesting<TClass>
    {
        TClass NewTestInstance();
    }

    public interface IInstanceTesting<TClass, TParam>
    {
        TClass NewTestInstance(TParam param);
    }

    public interface IInstanceTesting<TClass, TParam1, TParam2>
    {
        TClass NewTestInstance(TParam1 param1, TParam2 param2);
    }
}
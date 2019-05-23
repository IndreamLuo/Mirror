namespace Mirror.Common.Model
{
    public abstract class Adaptable<TAdaptable>
    {
        public Adaptable(TAdaptable from)
        {
            IsAdapted = true;
        }

        public readonly bool IsAdapted;

        public abstract TAdaptable ToAdaptable();
    }
}
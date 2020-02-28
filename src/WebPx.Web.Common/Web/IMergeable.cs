namespace WebPx.Web
{
    public interface IMergeable
    {
        void Merge(object instance);
    }

    public interface IMergeable<T>
    {
        void Merge(T instance);
    }
}

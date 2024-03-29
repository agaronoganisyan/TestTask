using UniRx;

namespace PoolLogic
{
    public interface IPool<T>
    {
        void Setup(T prefab, int initialSize);
        T Pull();
        void PushBackAll();
    }
}
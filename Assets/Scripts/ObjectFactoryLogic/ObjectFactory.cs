using Cysharp.Threading.Tasks;
using PoolLogic;
using UnityEngine;

namespace ObjectFactoryLogic
{
    public abstract class ObjectFactory<T> : IFactory<T> where T : MonoBehaviour, IPoolable<T>
    {
        protected IPool<T> _pool;

        public abstract UniTask Setup();

        public T Get()
        {
            return _pool.Pull();
        }

        public void ReturnAllObjectToPool()
        {
            _pool.PushBackAll();
        }
    }
}
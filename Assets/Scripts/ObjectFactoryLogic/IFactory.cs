namespace ObjectFactoryLogic
{
    public interface IFactory<T>
    {
        T Get();
    }
}
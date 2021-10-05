namespace Project.Scripts.Factories
{
    public interface IFactory<out T>
    {
        T Create();
    }
}
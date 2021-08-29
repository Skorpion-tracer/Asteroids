namespace Asteroids.Abstract_Factory
{
    public interface IPlatform
    {
        IInput Input { get; }
        IWindow Window { get; }
    }
}
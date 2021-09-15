namespace Asteroids.Abstract_Factory
{
    public sealed class Platform : IPlatform
    {
        public IInput Input { get; }
        public IWindow Window { get; }

        public Platform(IInput input, IWindow window)
        {
            Input = input;
            Window = window;
        }
    }
}
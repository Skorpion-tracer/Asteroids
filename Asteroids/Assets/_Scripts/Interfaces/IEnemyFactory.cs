namespace Asteroids
{
    public interface IEnemyFactory
    {
        Enemy CreateAsteroid(Health hp);
        Enemy CreateSpaceGarbage(Health hp);
    }
}

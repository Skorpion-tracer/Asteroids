using Asteroids.Helper;

namespace Asteroids
{
    public class MagFactory
    {
        public Mag CreateMag(Unit unit)
        {
            Mag mag = new Mag();
            mag.Health = new Health(float.Parse(unit.health), float.Parse(unit.health));
            return mag;
        }
    }
}

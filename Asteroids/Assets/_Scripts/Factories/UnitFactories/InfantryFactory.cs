using Asteroids.Helper;

namespace Asteroids
{
    public class InfantryFactory
    {
        public Infantry CreateInfantry(Unit unit)
        {
            Infantry infantry = new Infantry();
            infantry.Health = new Health(float.Parse(unit.health), float.Parse(unit.health));
            return infantry;
        }
    }
}

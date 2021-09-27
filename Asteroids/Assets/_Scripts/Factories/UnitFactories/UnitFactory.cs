using Asteroids.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    public class UnitFactory
    {
        private InfantryFactory _infantryFactory;
        private MagFactory _magFactory;

        public UnitFactory()
        {
            _infantryFactory = new InfantryFactory();
            _magFactory = new MagFactory();
        }

        public Bot CreateBot(Unit unit)
        {
            switch (unit.type)
            {
                case "infantry":
                    return _infantryFactory.CreateInfantry(unit);

                case "mag":
                    return _magFactory.CreateMag(unit);

                default: return null;
            }
        }
    }
}

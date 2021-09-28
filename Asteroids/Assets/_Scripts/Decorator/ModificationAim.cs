using UnityEngine;

namespace Decorator
{
    public class ModificationAim : ModificationWeapon
    {
        private readonly IAim _aim;
        private readonly Vector3 _aimPosition;

        GameObject _aimGO;

        public ModificationAim(IAim aim, Vector3 aimPosition)
        {
            _aim = aim;
            _aimPosition = aimPosition;
        }
        public override void RemoveModification()
        {
            if (_aimGO.activeInHierarchy)
            {
                Object.Destroy(_aimGO);
            }
        }

        protected override Weapon AddModification(Weapon weapon)
        {
            _aimGO = Object.Instantiate(_aim.AimInstance, _aimPosition, Quaternion.Euler(90, 0, 0));
            weapon.SetAimPosition(_aimGO.transform);
            return weapon;
        }
    }
}

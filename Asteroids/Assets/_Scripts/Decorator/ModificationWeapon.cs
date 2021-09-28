namespace Decorator
{
    public abstract class ModificationWeapon : IFire
    {
        private Weapon _weapon;

        protected abstract Weapon AddModification(Weapon weapon);
        public abstract void RemoveModification();

        public void ApplyModification(Weapon weapon)
        {
            _weapon = AddModification(weapon);
        }

        public void Fire()
        {
            _weapon.Fire();
        }

    }
}

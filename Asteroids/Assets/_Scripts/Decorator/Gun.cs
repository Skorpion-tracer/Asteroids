using UnityEngine;

namespace Decorator
{
    public sealed class Gun : MonoBehaviour
    {
        private IFire _fire;
        [Header("Start Gun")]
        [SerializeField] private Rigidbody _bullet;
        [SerializeField] private Transform _barrelPosition;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;

        [Header("Muffler Gun")]
        [SerializeField] private AudioClip _audioClipMuffler;
        [SerializeField] private float _volumeFireOnMuffler;
        [SerializeField] private Transform _barrelPositionMuffler;
        [SerializeField] private Transform _positionMuffler;
        [SerializeField] private GameObject _muffler;

        [Header("Aim")]
        [SerializeField] private GameObject _aim;
        [SerializeField] private Transform _positionAim;

        private Weapon _weapon;
        private ModificationWeapon _modificationWeapon;
        private ModificationAim _modificationAim;

        private void Start()
        {
            var muffler = new Muffler(_audioClipMuffler, _volumeFireOnMuffler, _barrelPositionMuffler, _muffler);
            _modificationWeapon = new ModificationMuffler(_audioSource, muffler, _positionMuffler.position);

            var aim = new Aim(_aim);
            _modificationAim = new ModificationAim(aim, _positionAim.position);

            RemoveMuffler();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _fire.Fire();
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                SetMuffler();
            }

            if (Input.GetKeyDown(KeyCode.G))
            {
                RemoveMuffler();
                _modificationWeapon.RemoveModification();
            }

            if (Input.GetKeyDown(KeyCode.H))
            {
                SetAim();
            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                _modificationAim.RemoveModification();
            }
        }

        private void SetMuffler()
        {
            _fire = _modificationWeapon;
            _modificationWeapon.ApplyModification(_weapon);
        }

        private void SetAim()
        {
            _modificationAim.ApplyModification(_weapon);
        }

        private void RemoveMuffler()
        {
            IAmmunition ammunition = new Bullet(_bullet, 3.0f);
            _weapon = new Weapon(ammunition, _barrelPosition, 999.0f, _audioSource, _audioClip);

            _fire = _weapon;
        }
    }
}

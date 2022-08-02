using System.Collections;
using UnityEngine;

namespace Assets.Level4.Scripts
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private float _bulletCount;
        [SerializeField] private Bullet _bullet;
        [SerializeField] private Transform _shotPoint;
        [SerializeField] private float _reloadTime;
        [SerializeField] private AudioSource _shotSound;
        private bool _gunReloaded = true;
        public virtual void Shoot() =>
            Instantiate(_bullet, _shotPoint.transform.position, _shotPoint.rotation);
        private void Update()
        {
            if (Input.GetMouseButton(0) && _gunReloaded) 
            {
                Shoot();
                _shotSound.Play();
                _gunReloaded = false;
                StartCoroutine(ReloadGun());
            }
        }
        private IEnumerator ReloadGun()
        {
            yield return new WaitForSeconds(_reloadTime);
             _gunReloaded = true;
        }
    }
}
using UnityEngine;
namespace Asteroid
{
    public sealed class Fire : IFire
    {
        private readonly Rigidbody2D _bullet;
        private readonly Transform _barrel;
        private readonly float _bulletForce;

        public Fire(Rigidbody2D bullet, Transform barrel, float bulletForce)
        {
            _bullet = bullet;
            _barrel = barrel;
            _bulletForce = bulletForce;
        }

        public void Shoot()
        {
            Rigidbody2D tempAmmunition = Object.Instantiate(_bullet, _barrel.position, _barrel.rotation);
            tempAmmunition.AddForce(_barrel.up * _bulletForce);
            Object.Destroy(tempAmmunition.gameObject, 3.0f);
        }
    }
}
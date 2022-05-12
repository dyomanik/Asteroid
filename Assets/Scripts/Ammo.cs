using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Asteroid 
{
    public class Ammo : IFire
    {
        private readonly Transform _barrel;
        private readonly float _bulletForce;
        private readonly BulletPool _bulletPool;
        private readonly Bullet _bulletAmmo;

        public Ammo(Transform barrel, float bulletForce)
        {
            _barrel = barrel;
            _bulletForce = bulletForce;
            _bulletPool = new BulletPool(3);
            _bulletAmmo = _bulletPool.GetAmmo(NameConstants.BULLET);
        }

        public void Shoot()
        {
            _bulletAmmo.ActiveBullet(_barrel, _bulletForce);
        }
    }
}
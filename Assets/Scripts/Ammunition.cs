using UnityEngine;
namespace Asteroid 
{
    public sealed class Ammunition : IFire
    {
        private readonly Transform _barrel;
        private readonly float _bulletForce;
        private BulletByBuilder _bulletByBuilder;

        public Ammunition(Transform barrel, float bulletForce)
        {
            _barrel = barrel;
            _bulletForce = bulletForce;
        }

        public void Shoot()
        {
            _bulletByBuilder = new BulletByBuilder();
            _bulletByBuilder.ActiveBullet(_barrel, _bulletForce);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Asteroid 
{
    public class Ammunition :IFire
    {
        private readonly Rigidbody2D _bullet;
        private readonly ICreate _create;

        public Ammunition(Rigidbody2D bullet, ICreate create)
        {
            _bullet = bullet;
            _create = create;
        }
        public void Shoot()
        {
            var bullet = _create.Instantiate<Rigidbody2D>(_bullet.gameObject);
            bullet.AddForce(Vector2.up);
            //_create.Destroy(_bullet.gameObject);
        }
    }
}
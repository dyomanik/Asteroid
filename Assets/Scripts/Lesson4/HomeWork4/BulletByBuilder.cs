using UnityEngine;
namespace Asteroid
{
    public sealed class BulletByBuilder
    {
        private readonly float _radiusOfCircleCollider = 0.5f;
        private readonly float _mass = 1.0f;
        private readonly int _orderInLayer = 1;
        private readonly float _scaleOfBullet = 0.15f;
        private readonly float _gravityScale = 0f;
        private readonly float _linearDrag = 0.5f;
        private GameObject _bullet;
        private Rigidbody2D _rigidbody;

        public BulletByBuilder()
        {
            _bullet = new GameObject()
                                      .SetName(NameConstants.BULLET)
                                      .AddCircleCollider2D(_radiusOfCircleCollider)
                                      .AddRigidbody2D(_mass,_gravityScale,_linearDrag)
                                      .AddSprite(Resources.Load<Sprite>(NameConstants.CIRCLE), Color.red, _orderInLayer);
            _bullet.tag = NameConstants.BULLET;
            _bullet.transform.localScale = Vector3.one*_scaleOfBullet;
            _bullet.layer = LayerMask.NameToLayer(NameConstants.BULLET);
            _rigidbody = _bullet.GetComponent<Rigidbody2D>();
        }
        public void ActiveBullet(Transform barrel, float bulletForce)
        {
            _bullet.transform.position = barrel.position;
            _bullet.transform.rotation = barrel.rotation;
            _rigidbody.AddForce(barrel.up * bulletForce);
            Object.Destroy(_bullet,3f);
        }
    }
}
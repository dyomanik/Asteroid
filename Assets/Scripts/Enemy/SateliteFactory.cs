using UnityEngine;
namespace Asteroid
{
    internal sealed class SateliteFactory : IEnemyFactory
    {
        private readonly float _minScale = 0.3f;
        private readonly float _maxScale = 0.6f;
        private readonly float _minAngle = 0f;
        private readonly float _maxAngle = 359.0f;
        public Enemy Create(Health healthPoints)
        {
            var enemy = Object.Instantiate(Resources.Load<Satelite>("Enemy/Satelite"));
            var randomScale = Random.Range(_minScale, _maxScale);
            var randomRotation = Random.Range(_minAngle, _maxAngle);
            enemy.transform.rotation = Quaternion.AngleAxis(randomRotation, Vector3.forward);
            enemy.transform.localScale = new Vector3(randomScale, randomScale);
            enemy.DependencyInjectHealth(healthPoints);
            return enemy;
        }
    }
}
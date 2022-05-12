using UnityEngine;
namespace Asteroid
{
    internal sealed class AsteroidFactory : IEnemyFactory
    {
        public Enemy Create(Health healthPoints)
        {
            var enemy = Object.Instantiate(Resources.Load<Asteroids>("Enemy/Asteroid"));
            enemy.DependencyInjectHealth(healthPoints);
            return enemy;
        }
    }
}
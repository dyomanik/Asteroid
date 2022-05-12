using UnityEngine;
using Asteroid.Object_Pool;
using System.Collections.Generic;
namespace Asteroid
{
    internal sealed class EnemyController : IExecute
    {
        private readonly List<Transform> _respawnEnemies;
        private readonly float _lifetime = 5f;
        private float timer = 0f;
        private EnemyPool _enemyPool;
        private Enemy _enemy;
        public EnemyController (List<Transform> respawnEnemies)
        {
            _respawnEnemies = respawnEnemies;
            for (int i = 0; i < _respawnEnemies.Count; i++)
            {
                _enemyPool = new EnemyPool(4);
                _enemy = _enemyPool.GetEnemy(TypeOfEnemy.RandomEnemy());
                _enemy.ActiveEnemy(_respawnEnemies[i].position, Quaternion.identity);
            }
        }

        public void Execute()
        {
            timer += Time.deltaTime;
            if (timer > _lifetime)
            {
                var respawnNumber = Random.Range(0, _respawnEnemies.Count);
                _enemy.ActiveEnemy(_respawnEnemies[respawnNumber].position, Quaternion.identity);
                timer = 0f;
            }
        }
    }
}
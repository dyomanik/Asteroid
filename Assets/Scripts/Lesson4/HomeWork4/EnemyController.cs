using UnityEngine;
using Asteroid.Object_Pool;
using System.Collections.Generic;
using Asteroid.ServiceLocatore;
namespace Asteroid
{
    internal sealed class EnemyController : IExecute
    {
        private readonly List<Transform> _respawnEnemies;
        private readonly float _lifetime = 5f;
        private float _timer = 0f;
        private readonly int _numberOfRespawns;
        private EnemyPool _enemyPool;
        private Enemy _enemy;
        public EnemyController (List<Transform> respawnEnemies)
        {
            _respawnEnemies = respawnEnemies;
            _numberOfRespawns = respawnEnemies.Count;
            for (int i = 0; i < _respawnEnemies.Count; i++)
            {
                _enemyPool = new EnemyPool(_numberOfRespawns);
                _enemy = _enemyPool.GetEnemy(TypeOfEnemy.RandomEnemy());
                _enemy.ActiveEnemy(_respawnEnemies[i].position, Quaternion.identity);
                var enemy = _enemy.Clone();
                enemy.ActiveEnemy(new Vector3(-3f,-3f,0f), Quaternion.identity);
                ServiceLocator.Register<EnemyPool>(new EnemyPool(1));
            }
        }

        public void Execute()
        {
            _timer += Time.deltaTime;
            if (_timer > _lifetime)
            {
                var respawnNumber = Random.Range(0, _respawnEnemies.Count);
                _enemy.ActiveEnemy(_respawnEnemies[respawnNumber].position, Quaternion.identity);
                _timer = 0f;
            }
        }
    }
}
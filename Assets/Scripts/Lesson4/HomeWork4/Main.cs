using System.Collections.Generic;
using UnityEngine;
using Asteroid.ServiceLocatore;
using Asteroid.Object_Pool;
namespace Asteroid
{
    internal sealed class Main : MonoBehaviour
    {
        private InputController _inputController;
        private EnemyController _enemyController;
        [SerializeField]
        private List<Transform> _respawnEnemies;
        private Reference _reference;
        private List<IExecute> _listExecuteObjects;
       
        private void Start()
        {
            _reference = new Reference();
            _listExecuteObjects = new List<IExecute>();

            _inputController = new InputController(_reference.player, _reference.cameraMain);
            _enemyController = new EnemyController(_respawnEnemies);
            
            _listExecuteObjects.Add(_inputController);
            _listExecuteObjects.Add(_enemyController);
            ServiceLocator.GetService<EnemyPool>().GetEnemy(NameConstants.ASTEROID).ActiveEnemy(new Vector3(-2f,-2f,0f),Quaternion.identity);
        }

        private void Update()
        {
            for (int i = 0; i < _listExecuteObjects.Count; i++)
            {
                _listExecuteObjects[i].Execute();
            }
        }
    }
}
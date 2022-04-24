using System.Collections.Generic;
using UnityEngine;
namespace Asteroid
{
    public sealed class Main : MonoBehaviour
    {
        private InputController _inputController;
        private Reference _reference;
        private List<IExecute> _listExecuteObjects;
       

        private void Start()
        {
            _reference = new Reference();
            _listExecuteObjects = new List<IExecute>();

            _inputController = new InputController(_reference.player, _reference.cameraMain);
            
            _listExecuteObjects.Add(_inputController);
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
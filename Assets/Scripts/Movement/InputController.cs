using UnityEngine;
namespace Asteroid
{
    internal sealed class InputController : IExecute
    {
        private readonly Player _player;
        private readonly Camera _camera;
        private float _horizontal;
        private float _vertical;

        public InputController(Player player, Camera camera)
        {
            _player = player;
            _camera = camera;
        }

        public void Execute()
        {
            Vector3 direction = Input.mousePosition - _camera.WorldToScreenPoint(_player.transform.position);
            _horizontal = Input.GetAxis(InputConstants.horizontal);
            _vertical = Input.GetAxis(InputConstants.vertical);
            _player.ship.Move(_horizontal,_vertical,Time.deltaTime);
            _player.ship.Rotation(direction);
            
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _player.ship.AddAcceleration();
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _player.ship.RemoveAcceleration();
            }
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                _player.firing.Shoot();
            }
        } 
    }
}
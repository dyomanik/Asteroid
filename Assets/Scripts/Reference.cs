using UnityEngine;
namespace Asteroid
{
    public sealed class Reference
    {
        private Player _player;
        private Camera _mainCamera;

        public Player player
        {
            get
            {
                if (_player == null)
                {
                    Player gameObject = Resources.Load<Player>("Player");
                    _player = Object.Instantiate(gameObject);
                }
                return _player;
            }

        }

        public Camera cameraMain
        {
            get
            {
                if (!_mainCamera)
                {
                    _mainCamera = Camera.main;
                }
                return _mainCamera;
            }
            set => _mainCamera = value;
        }
    }
}
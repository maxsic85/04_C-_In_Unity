using UnityEngine;

namespace Labirint.Core
{
    internal class PlayerShootController:IExecute
    {
        private readonly InputController _inputController;
        private BuiletData _bulletData;
        private BuiletFactory _builetFactory;

        private Transform _bulletStartTransform;
        public PlayerShootController(InputController inputController, BuiletData builetData, BuiletFactory builetFactory, Transform bulletStartTransform )
        {
            _inputController = inputController;
            _bulletData = builetData;
            _builetFactory = builetFactory;
            _bulletStartTransform = bulletStartTransform;
        }
        public void Fire()
        {
            if (_inputController.GetFire())
            {
                var currentBuilet = _builetFactory.CreateBuilet(_bulletStartTransform);
                currentBuilet.GetComponent<Rigidbody>().AddForce(_bulletStartTransform.transform.forward * _bulletData._baseSpeed);

            }
        }
        public void Execute(float deltaTime)
        {
            Fire();
        }
    }
}
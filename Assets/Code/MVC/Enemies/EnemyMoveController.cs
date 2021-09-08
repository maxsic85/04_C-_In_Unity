using UnityEngine;
namespace MAX.CODE.MVC
{
    public class EnemyMoveController : IExecute
    {
        private readonly Imove _move;
        private readonly Transform _target;

        public EnemyMoveController(Imove move, Transform target)
        {
            _move = move;
            _target = target;
        }

        public void Execute(float deltaTime)
        {
            _move?.Move(_target.localPosition);

        }


    }
}
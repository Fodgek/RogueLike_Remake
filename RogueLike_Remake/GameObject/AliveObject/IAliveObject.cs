using RogueLike_Remake.GameObject.Structs;

namespace RogueLike_Remake.GameObject.AliveObject
{
    internal interface IAliveObject : IGameObject
    {
        public bool _IsAlive { get; }
        public void Move(Direction direction);
        public void Attack(IGameObject gameObject);
        public void Damaged(int value);
    }
}

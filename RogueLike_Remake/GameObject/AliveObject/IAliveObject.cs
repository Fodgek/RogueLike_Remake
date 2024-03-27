using RogueLike_Remake.GameObject.Structs;
using RogueLike_Remake.Weapon;

namespace RogueLike_Remake.GameObject.AliveObject
{
    internal interface IAliveObject : IGameObject
    {
        public Health _Health { get; }
        public bool _IsAlive { get; }
        public IWeapon _Weapon { get; }

        public event Action<IAliveObject, Direction>? Moved;
        public event Action<IAliveObject, WeaponType, int, int>? Attacked;
        public event Action<IAliveObject>? Dead;
        public void Move(Direction direction);
        public void Attack();
        public void Damaged(int value);
    }
}

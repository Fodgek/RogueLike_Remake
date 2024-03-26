using RogueLike_Remake.GameObject.Structs;

namespace RogueLike_Remake.GameObject.AddedObject.Bullet
{
    internal interface IBullet : IGameObject
    {
        public int _Damage {  get; }

        public event Action<Bullet>? DelBullet;
        public event Action<Bullet>? Moving;

        public void Destroy();
    }
}

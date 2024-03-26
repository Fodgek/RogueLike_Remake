using RogueLike_Remake.GameObject.AddedObject.Bullet;
using RogueLike_Remake.GameObject.AliveObject;
using RogueLike_Remake.GameObject.Structs;

namespace RogueLike_Remake.GameObject
{
    internal interface IGameObject
    {
        public Guid Id { get; }
        public string _Name { get; }
        public string _Description { get; }
        public string _Tag { get; }
        public bool _IsPasable {  get; }
        public Sprite _Sprite { get; }
        public Position _Position { get; }
        public bool _OnDel { get; }

        public void Info();
        public void LowInfo();
        public IGameObject ChPosClone(Position pos);
        public void SetPos(Position pos);
        public void Damaged(int value);
        public void DelMe();
    }
}

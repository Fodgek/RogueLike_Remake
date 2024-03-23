using RogueLike_Remake.GameObject.Structs;

namespace RogueLike_Remake.GameObject
{
    internal interface IGameObject
    {
        public Guid Id { get; }
        public string _Name { get; }
        public string _Description { get; }
        public string _Tag { get; }
        public Sprite _Sprite { get; }
        public Position _Position { get; }
        public Health _Health { get; }

        public void Info();
        public void LowInfo();
        public IGameObject ChPosClone(Position pos);
        public void DrawMe();
    }
}

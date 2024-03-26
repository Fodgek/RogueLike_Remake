using RogueLike_Remake.GameObject.Structs;

namespace RogueLike_Remake.GameObject.StaticObject
{
    internal interface IStaticObject : IGameObject 
    {
        public Health _Health { get; }
    }
}

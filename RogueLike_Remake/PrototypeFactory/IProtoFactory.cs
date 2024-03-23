using RogueLike_Remake.GameObject.Structs;
using RogueLike_Remake.GameObject;

namespace RogueLike_Remake.PrototypeFactory
{
    internal interface IProtoFactory
    {
        IGameObject Create(string protoTag, Position position);
    }
}

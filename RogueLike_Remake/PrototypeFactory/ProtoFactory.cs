using RogueLike_Remake.GameObject;
using RogueLike_Remake.GameObject.StaticObject;
using RogueLike_Remake.GameObject.Structs;

namespace RogueLike_Remake.PrototypeFactory
{
    internal class ProtoFactory : IProtoFactory
    {
        private readonly Dictionary<string, IGameObject> prototypes = new Dictionary<string, IGameObject> { };

        public ProtoFactory()
        {
            InitProto();
        }
        private void InitProto()
        {
            prototypes["Plate"] = new StaticObject("Плитка", "Плитка пола, может сломаться, наверное", "Plate", new Sprite('_'), new Position(10, 10), new Health(1000));
            prototypes["Wall"] = new StaticObject("Стена", "Обычная Стена, тут только такие", "Plate", new Sprite('_'), new Position(10, 10), new Health(1000));
        }
        public IGameObject Create(string protoTag, Position position)
        {
            return (prototypes.TryGetValue(protoTag, out IGameObject? gameObj) ? gameObj.ChPosClone(position) : throw new ArgumentException("Нет такого прототипа {0}",protoTag));
        }
    }
}

using RogueLike_Remake.GameObject;
using RogueLike_Remake.GameObject.AddedObject.Bullet;
using RogueLike_Remake.GameObject.AliveObject;
using RogueLike_Remake.GameObject.StaticObject;
using RogueLike_Remake.GameObject.Structs;
using RogueLike_Remake.WeaponFactory;

namespace RogueLike_Remake.PrototypeFactory
{
    internal class ProtoFactory : IProtoFactory
    {
        private readonly Dictionary<string, IGameObject> prototypes = new Dictionary<string, IGameObject> { };
        private readonly IWeaponFactory weaponFactory = new RogueLike_Remake.WeaponFactory.WeaponFactory();

        public ProtoFactory()
        {
            InitProto();
        }
        private void InitProto()
        {
            prototypes["Plate"] = new StaticObject("Плитка", "Плитка пола, может сломаться, наверное", true, new Sprite('_'), new Position(0, 0), new Health(1000));
            prototypes["Wall"] = new StaticObject("Стена", "Обычная Стена, тут только такие", false, new Sprite('#'), new Position(0, 0), new Health(1000));
            prototypes["Player"] = new AliveObject("Игрок","Текущий игрок", false, new Sprite('&'), new Position(0,0),new Health(10),weaponFactory.Create("Sword"));
            prototypes["Zombe"] = new AliveObject("Зомби", "Гнилой труп", false, new Sprite('Z'), new Position(0, 0), new Health(5), weaponFactory.Create("Arm"));
            prototypes["Sceleton"] = new AliveObject("Скелет", "Живые кости, как только стреляют?", false, new Sprite('S'), new Position(0, 0), new Health(1), weaponFactory.Create("Bow"));
        }
        public IGameObject Create(string protoTag, Position position)
        {
            return (prototypes.TryGetValue(protoTag, out IGameObject? gameObj) ? gameObj.ChPosClone(position) : throw new ArgumentException("Нет такого прототипа {0}",protoTag));
        }
    }
}

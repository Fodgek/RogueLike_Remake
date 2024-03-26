using RogueLike_Remake.GameObject;
using RogueLike_Remake.GameObject.AddedObject.Bullet;
using RogueLike_Remake.GameObject.AliveObject;
using RogueLike_Remake.GameObject.Structs;

namespace RogueLike_Remake.GameScene.Map
{
    internal interface IRoom
    {
        Guid Id { get; }
        public int _width { get; }
        public int _height { get; }
        public bool _OnDel {  get; }
        public List<IGameObject> _gameObjects { get; }
        public void Add(IGameObject obj);
        public bool DelById(Guid id);
        public IGameObject? FindById(Guid id);
        public IGameObject? FindByPos(Position pos,string tag);
        public void DelRoom();
        public void Clr();
        public void Info();
    }
}

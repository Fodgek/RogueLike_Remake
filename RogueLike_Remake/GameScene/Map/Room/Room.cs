using RogueLike_Remake.GameObject;
using RogueLike_Remake.GameObject.AliveObject;
using RogueLike_Remake.GameObject.Structs;

namespace RogueLike_Remake.GameScene.Map
{
    internal class Room : IRoom
    {
        public Guid Id { get; }
        public int _width { get; }
        public int _height { get ; }
        public bool _OnDel {  get; private set; }
        public List<IGameObject> _gameObjects { get; } = new List<IGameObject>();
        public void Add(IGameObject obj)
        {
            _gameObjects.Add(obj);
        }
        public bool DelById(Guid id)
        {
            var obj = FindById(id);
            if (obj == null) return false;
            _gameObjects.Remove(obj);
            return true;
        }
        public IGameObject? FindById(Guid id) => _gameObjects.FirstOrDefault(obj => obj.Id == id);
        public IGameObject? FindByPos(Position pos, string tag) => _gameObjects.Find(obj => obj._Position == pos && obj._Tag == tag);
        public void DelRoom()
        {
            this.Clr();
            _OnDel = true;
        }
        public void Clr()
        {
            _gameObjects.Clear();
        } 
        public void Info()
        {
            Console.WriteLine("Room GUID: {0}", Id);
        }
        public Room(int width, int height)
        {
            Id = Guid.NewGuid();
            _width = width;
            _height = height;
            _OnDel = false;
        }
    }
}

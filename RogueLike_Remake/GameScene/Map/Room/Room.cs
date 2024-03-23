using RogueLike_Remake.GameObject;

namespace RogueLike_Remake.GameScene.Map
{
    internal class Room : IRoom
    {
        public Guid Id { get; } = Guid.NewGuid();
        public int _width { get; }
        public int _height { get ; }
        public List<IGameObject> _gameObjects { get; } = new List<IGameObject>();
        public void Add(IGameObject obj) => _gameObjects.Add(obj);
        public bool Del(Guid id)
        {
            var obj = FindById(id);
            return obj != null && _gameObjects.Remove(obj);
        }
        public IGameObject? FindById(Guid id) => _gameObjects.FirstOrDefault(obj => obj.Id == id);
        public void Clr() => _gameObjects.Clear();
        public Room(int width, int height)
        {
            Id = Guid.NewGuid();
            _width = width;
            _height = height;
        }
    }
}

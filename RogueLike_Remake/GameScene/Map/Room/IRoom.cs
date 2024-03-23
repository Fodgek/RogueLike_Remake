using RogueLike_Remake.GameObject;

namespace RogueLike_Remake.GameScene.Map
{
    internal interface IRoom
    {
        Guid Id { get; }
        public int _width { get; }
        public int _height { get; }
        public List<IGameObject> _gameObjects {  get; }
        public void Add(IGameObject obj);
        public bool Del(Guid id);
        public IGameObject? FindById(Guid id);
        public void Clr();
    }
}

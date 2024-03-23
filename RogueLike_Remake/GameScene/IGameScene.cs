using RogueLike_Remake.GameScene.Map;

namespace RogueLike_Remake.GameScene
{
    internal interface IGameScene
    {
        public List<IMap> Maps { get; }
        public void Add(IMap obj);
        public bool Del(Guid id);
        public IMap? FindById(Guid id);
        public void Clr();
    }
}

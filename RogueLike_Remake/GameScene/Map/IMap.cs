namespace RogueLike_Remake.GameScene.Map
{
    internal interface IMap
    {
        Guid Id { get; }
        public string _Name { get; }
        public int _RoomCount { get; }
        public List<IRoom> _Rooms { get; }
        public void Add(IRoom obj);
        public bool Del(Guid id);
        public IRoom? FindById(Guid id);
        public void Clr();
    }
}

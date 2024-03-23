namespace RogueLike_Remake.GameScene.Map
{
    internal class Map : IMap
    {
        public Guid Id { get; }

        public string _Name { get; } = string.Empty;

        public int _RoomCount { get; }

        public List<IRoom> _Rooms { get; } = new List<IRoom>();
        public void Add(IRoom obj) => _Rooms.Add(obj);
        public bool Del(Guid id)
        {
            var obj = FindById(id);
            return obj != null && _Rooms.Remove(obj);
        }
        public IRoom? FindById(Guid id) => _Rooms.FirstOrDefault(obj => obj.Id == id);
        public void Clr() => _Rooms.Clear();
        public Map(string name, int roomCount)
        {
            Id = Guid.NewGuid();
            _Name = name;
            _RoomCount = roomCount;
        }
    }
}

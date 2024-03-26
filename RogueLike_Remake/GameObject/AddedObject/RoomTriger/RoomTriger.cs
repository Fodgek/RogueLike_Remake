using RogueLike_Remake.GameObject.AliveObject;
using RogueLike_Remake.GameObject.Structs;


namespace RogueLike_Remake.GameObject.AddedObject.RoomTriger
{
    internal class RoomTriger : IGameObject, IRoomTriger
    {
        public Guid Id { get; }
        public Guid _PrevRoomId { get; private set; }
        public Guid _NextRoomId { get; private set; }
        public string _Name { get; } = "Triger";
        public string _Description { get; } = "Triger";
        public string _Tag { get; } = "Triger";
        public bool _IsPasable { get; }
        public Sprite _Sprite { get; }
        public Position _Position { get; private set; }
        public bool _OnDel { get; }

        public RoomTriger(Guid prevRoomId, Guid nextRoomId, bool ispasable, Sprite sprite, Position position)
        {
            Id = Guid.NewGuid();
            _PrevRoomId = prevRoomId;
            _NextRoomId = nextRoomId;
            _IsPasable = ispasable;
            _Sprite = sprite;
            _Position = position;
            _OnDel = false;
        }
        public void Info() { }
        public void LowInfo() { }
        public IGameObject RevClonePos(Position pos, Guid prevRoomId, Guid nextRoomId) => new RoomTriger(prevRoomId, nextRoomId, _IsPasable, _Sprite, pos);
        public IGameObject ChPosClone(Position pos) => new RoomTriger(_PrevRoomId, _NextRoomId, _IsPasable, _Sprite, pos);
        public void SetPos(Position pos) => _Position = pos;
        public void SetPrevRoomId(Guid id) => _PrevRoomId = id;
        public void SetNextRoomId(Guid id) => _NextRoomId = id;
        public void Damaged(int value) { }
        public void DelMe() { }
    }
}

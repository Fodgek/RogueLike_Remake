using RogueLike_Remake.GameConfiguration;
using RogueLike_Remake.GameObject.AddedObject.RoomTriger;
using RogueLike_Remake.GameObject.Structs;
using RogueLike_Remake.GameScene.Map;
using RogueLike_Remake.PrototypeFactory;

namespace RogueLike_Remake.GameScene.RoomGenerator
{
    internal class RoomGenerator : IRoomGenerator
    {
        private readonly IGameConfig _Config;
        private readonly IProtoFactory _ProtoFactory;
        private int _width = 3;
        private int _height = 3;
        public RoomGenerator(IGameConfig config, IProtoFactory factory)
        {
            _Config = config;
            _ProtoFactory = factory;
            SetSize();
        }
        public IRoom GenerateRoom()
        {
            IRoom room = new Room(_width, _height);
            FillRoom(room);
            AddEnity(room);
            return room;
        }
        private void SetSize()
        {
            switch (_Config._RoomSize)
            {
                case Size.Small: _width = 7; break;
                case Size.Medium: _width = 11; break;
                case Size.Big: _width = 21; break;
            }
            _height = _width;
        }
        private void FillRoom(IRoom room)
        {
            for (int x = 0; x < _width; x++)
                for (int y = 0; y < _height; y++)
                {
                    if ((x == 0 && !(y == _width / 2)) || (x == _width - 1 && !(y == _width / 2)))
                        room.Add(_ProtoFactory.Create("Wall", new Position(x, y)));
                    else if ((y == 0 && !(x == _height / 2)) || (y == _height - 1 && !(x == _height / 2)))
                        room.Add(_ProtoFactory.Create("Wall", new Position(x, y)));
                    else if ((x == 0 && (y == _width / 2)) || (x == _width - 1 && (y == _width / 2)))
                        room.Add(new RoomTriger(room.Id, Guid.Empty, true, new Sprite('t'), new Position(x, y)));
                    else if ((y == 0 && (x == _height / 2)) || (y == _height - 1 && (x == _height / 2)))
                        room.Add(new RoomTriger(room.Id, Guid.Empty, true, new Sprite('t'), new Position(x, y)));
                    else
                        room.Add(_ProtoFactory.Create("Plate", new Position(x, y)));
                }
        }
        private void AddEnity(IRoom room)
        {
            room.Add(_ProtoFactory.Create("Zombe", new Position(_width-2, _height-2)));
            room.Add(_ProtoFactory.Create("Sceleton", new Position(1, 1)));
        }
    }
}

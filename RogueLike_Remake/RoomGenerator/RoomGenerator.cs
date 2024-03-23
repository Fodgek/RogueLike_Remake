using RogueLike_Remake.GameConfiguration;
using RogueLike_Remake.GameObject.StaticObject;
using RogueLike_Remake.GameObject.Structs;
using RogueLike_Remake.GameScene.Map;
using RogueLike_Remake.PrototypeFactory;

namespace RogueLike_Remake.RoomGenerator
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
            return room;
        }
        private void SetSize() 
        {
            switch (_Config._RoomSize) 
            {
                case Size.Small: _width = 7; break;
                case Size.Medium: _width = 12; break;
                case Size.Big: _width = 22; break;
            }
            _height = _width;
        }
        private void FillRoom(IRoom room)
        {
            for (int x = 0; x < _width; x++)
                for(int y = 0; y < _height; y++)
                {
                    room.Add(_ProtoFactory.Create("Plate",new Position(x,y)));
                }
        }
    }
}

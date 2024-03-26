using RogueLike_Remake.EventCatcher;
using RogueLike_Remake.GameConfiguration;
using RogueLike_Remake.GameObject;
using RogueLike_Remake.GameScene.Map;
using RogueLike_Remake.GameScene.RoomGenerator;
using RogueLike_Remake.PrototypeFactory;
using RogueLike_Remake.GameObject.Structs;

namespace RogueLike_Remake.GameInit
{
    internal class GameInit : IGameInit
    {
        private readonly IGameConfig _Config;
        private readonly IProtoFactory _Factory;
        private readonly IRoomGenerator _RoomGenerator;
        private readonly IMap _Map;
        private readonly IRoom _Room;
        private readonly ICatcher _Catcher;
        public GameInit(IGameConfig config, IProtoFactory Factory, IRoomGenerator RoomGenerator,IMap Map, ICatcher Catcher)
        {
            _Config = config;
            _Factory = Factory;
            _RoomGenerator = RoomGenerator;
            _Room = _RoomGenerator.GenerateRoom();
            _Map = Map;
            _Catcher = Catcher;
        }  
        public void Init() 
        {
            IGameObject player = _Factory.Create("Player", new Position(_Room._width/2,_Room._height/2));
            _Room.Add(player);
            _Map.Add(_Room);
        }
    }
}

using RogueLike_Remake.GameConfiguration;
using RogueLike_Remake.GameScene.Map;

namespace RogueLike_Remake.RoomGenerator
{
    internal interface IRoomGenerator
    {
        public IRoom GenerateRoom();
    }
}

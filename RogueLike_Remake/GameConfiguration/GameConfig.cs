namespace RogueLike_Remake.GameConfiguration
{
    internal class GameConfig : IGameConfig
    {
        public string _Name { get; } = "Configuration";
        public Size _RoomSize {  get; }
        public Difficult _Difficult {  get; }
        public GameConfig() 
        {
            _Name = "Configuration0";
            _RoomSize = Size.Small;
            _Difficult = Difficult.Hard;
        }
        public GameConfig(string name, Size roomSize, Difficult difficult)
        {
            _Name = name;
            _RoomSize = roomSize;
            _Difficult = difficult;
        }
    }
}

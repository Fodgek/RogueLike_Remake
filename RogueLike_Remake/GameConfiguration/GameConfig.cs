namespace RogueLike_Remake.GameConfiguration
{
    internal class GameConfig : IGameConfig
    {
        public string _Name { get; } = "Configuration";
        public string _PlayerName { get; }
        public Size _RoomSize {  get; }
        public Difficult _Difficult {  get; }
        public GameConfig() 
        {
            _Name = "Configuration0";
            _PlayerName = "Player1";
            _RoomSize = Size.Big;
            _Difficult = Difficult.Easy;
        }
        public GameConfig(string name,string player, Size roomSize, Difficult difficult)
        {
            _Name = name;
            _PlayerName = player;
            _RoomSize = roomSize;
            _Difficult = difficult;
        }
    }
}

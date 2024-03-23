namespace RogueLike_Remake.GameConfiguration
{
    internal interface IGameConfig
    {
        public string _Name { get; }
        public Size _RoomSize { get; }
        public Difficult _Difficult { get; }
    }
}

namespace RogueLike_Remake.GameObject
{
    internal interface IGameObject
    {
        Guid id { get; }
        string _Name { get; }
        string _Description { get; }
        string _Tag { get; }
        Sprite _Sprite { get; }
        Position _Position { get; }
        Health _Health { get; }

        public void Info();
        public void LowInfo();
    }
}

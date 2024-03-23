namespace RogueLike_Remake.GameObject.Structs
{
    public struct Sprite
    {
        public char _symbol { get; private set; }
        public Sprite() => _symbol = '_';
        public Sprite(char symbol) => _symbol = symbol;
    }
}

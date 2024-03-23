namespace RogueLike_Remake.GameObject.Structs
{
    public struct Health
    {
        public int _value { get; private set; }
        public Health() => _value = 0;
        public Health(int value) => _value = value;
        public void ChangeHealth(int value) => _value += value;
    }
}

namespace RogueLike_Remake.GameObject.Structs
{
    public class Health
    {
        public int _value { get; private set; }
        public Health(int value) => _value = value;
        public void ChangeHealth(int value) => _value += value;
        public void DegHealth(int value) => _value -= value;
    }
}

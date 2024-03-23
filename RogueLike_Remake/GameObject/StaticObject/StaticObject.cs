using RogueLike_Remake.GameObject.Structs;

namespace RogueLike_Remake.GameObject.StaticObject
{
    internal class StaticObject : IStaticObject
    {
        public Guid Id { get; }
        public string _Name {  get; } = "StaticObject";
        public string _Description { get; } = "Статичный Объект. Я его бью бью, а он никак не умирает";
        public string _Tag { get; } = "None";
        public Sprite _Sprite { get; }
        public Position _Position { get; set; }
        public Health _Health {  get; }

        public StaticObject(string name, string description, string tag, Sprite sprite, Position position, Health health)
        {
            Id = Guid.NewGuid();
            _Name = name;
            _Description = description;
            _Tag = tag;
            _Sprite = sprite;
            _Position = position;
            _Health = health;
        }
        public void Info()
        {
            Console.WriteLine("ID: {0}, Name: {1}, Description: {2}, Tag: {3}, Sprite: {4}, Position: {5}:{6}, Health: {7}",Id, _Name, _Description, _Tag, _Sprite._symbol, _Position._X, _Position._Y,_Health._value);
        }
        public void LowInfo()
        {
            Console.WriteLine("Name: {0}, Pos: {1}:{2}, HP: {3}", _Name, _Position._X, _Position._Y, _Health._value);
        }
        public IGameObject ChPosClone(Position pos)
        {
            return new StaticObject(_Name, _Description, _Tag, _Sprite, pos, _Health);
        }
        public void DrawMe()
        {
            Console.Write("{0,2}",_Sprite._symbol);
        }
    }
}

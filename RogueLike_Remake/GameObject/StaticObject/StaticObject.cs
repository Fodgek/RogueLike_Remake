using RogueLike_Remake.GameObject.AddedObject.Bullet;
using RogueLike_Remake.GameObject.AliveObject;
using RogueLike_Remake.GameObject.Structs;

namespace RogueLike_Remake.GameObject.StaticObject
{
    internal class StaticObject : IStaticObject
    {
        public Guid Id { get; }
        public string _Name {  get; } = "StaticObject";
        public string _Description { get; } = "Статичный Объект. Я его бью бью, а он никак не умирает";
        public string _Tag { get; } = "StaticObject";
        public bool _IsPasable {  get; }
        public Sprite _Sprite { get; }
        public Position _Position { get; set; }
        public Health _Health {  get; }
        public bool _OnDel { get; private set; }

        public StaticObject(string name, string description, bool ispasable, Sprite sprite, Position position, Health health)
        {
            Id = Guid.NewGuid();
            _Name = name;
            _Description = description;
            _IsPasable = ispasable;
            _Sprite = sprite;
            _Position = position;
            _Health = health;
            _OnDel = false;
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
            return new StaticObject(_Name, _Description, _IsPasable, _Sprite, pos, _Health);
        }
        public void SetPos(Position pos) => _Position = pos;
        public void Damaged(int value)
        {
            _Health.ChangeHealth(value);
        }
        public void DelMe() => _OnDel = true;
    }
}

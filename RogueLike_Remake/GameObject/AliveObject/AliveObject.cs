using RogueLike_Remake.GameObject.Structs;

namespace RogueLike_Remake.GameObject.AliveObject
{
    internal class AliveObject : IAliveObject
    {
        public Guid Id { get; }
        public string _Name { get; } = "AliveObject";
        public string _Description { get; } = "Живой Объект. Двигается заначит живой";
        public string _Tag { get; } = "None";
        public Sprite _Sprite { get; }
        public Position _Position { get; private set; }
        public Health _Health { get; }
        public bool _IsAlive { get; }

        public AliveObject(string name, string description, string tag, Sprite sprite, Position position, Health health)
        {
            Id = Guid.NewGuid();
            _Name = name;
            _Description = description;
            _Tag = tag;
            _Sprite = sprite;
            _Position = position;
            _Health = health;
            _IsAlive = health._value > 0 ? true : false;
        }

        public void Move(Direction direction) 
        {
            if (!_IsAlive) return;
            Position newPosition = _Position.ChangePos(direction);
            _Position = newPosition;
        }
        public void Attack(IGameObject gameObject) 
        {
            if (!_IsAlive) return;
        }
        public void Damaged(int value)
        {
            if (!_IsAlive) return;
            _Health.ChangeHealth(value);
        }
        public void Info()
        {
            Console.WriteLine("ID: {0}, Name: {1}, Description: {2}, Tag: {3}, Sprite: {4}, Position: {5}:{6}, Health: {7}, Alive: {8}", Id, _Name, _Description, _Tag, _Sprite._symbol, _Position._X, _Position._Y, _Health._value, _IsAlive);
        }
        public void LowInfo()
        {
            Console.WriteLine("Name: {0}, Pos: {1}:{2}, HP: {3}, Alive: {4}", _Name, _Position._X, _Position._Y, _Health._value, _IsAlive);
        }
        public IGameObject ChPosClone(Position pos)
        {
            return new AliveObject(_Name, _Description, _Tag, _Sprite, pos, _Health);
        }
        public void DrawMe()
        {
            Console.SetCursorPosition(_Position._X, _Position._Y);
            Console.WriteLine(_Sprite._symbol);
        }
    }
}

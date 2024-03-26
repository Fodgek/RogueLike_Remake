using RogueLike_Remake.GameObject;
using RogueLike_Remake.GameObject.AliveObject;

namespace RogueLike_Remake.Weapon
{
    internal class Weapon : IWeapon
    {
        public event Action<IAliveObject, WeaponType, int, int>? Attacked;

        public Guid Id { get; }
        public string _Name { get; }
        public string _Description { get; }
        public WeaponType _Type { get; }
        public int _MaxDistance { get; }
        public int _Damage { get; }
        public Weapon(string name, string description, WeaponType type, int MaxDistance, int damage)
        {
            Id = Guid.NewGuid();
            _Name = name;
            _Description = description;
            _Type = type;
            _MaxDistance = MaxDistance;
            _Damage = damage;
        }
        public IWeapon Clone() => new Weapon(_Name, _Description, _Type, _MaxDistance, _Damage);
    }
}

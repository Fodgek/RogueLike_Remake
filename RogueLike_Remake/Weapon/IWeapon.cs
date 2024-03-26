using RogueLike_Remake.GameObject;
using RogueLike_Remake.GameObject.AliveObject;
using RogueLike_Remake.GameObject.Structs;

namespace RogueLike_Remake.Weapon
{
    internal interface IWeapon
    {
        public Guid Id { get; }
        public string _Name { get; }
        public string _Description { get; }
        public WeaponType _Type { get; }
        public int _MaxDistance { get; }
        public int _Damage { get; }
        public IWeapon Clone();
    }
}

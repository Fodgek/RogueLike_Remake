using RogueLike_Remake.Weapon;

namespace RogueLike_Remake.WeaponFactory
{
    internal interface IWeaponFactory
    {
        IWeapon Create(string protoTag);
    }
}

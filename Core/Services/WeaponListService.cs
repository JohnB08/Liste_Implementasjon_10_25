using System;
using Core.Interfaces;
using Core.Models;

namespace Core.Services;

public class WeaponListService<TWeapon> : IWeaponListService<TWeapon> where TWeapon: IWeapon
{
    private readonly WeaponList<TWeapon> _weapons = new();

    public void AddWeapon(TWeapon weapon)
    {
        _weapons.InsertNewWeapon(weapon);
    }

    public void DeleteWeapon(Guid id)
    {
        var weapon = _weapons.First(weapon => weapon.Id == id);
        _weapons.RemoveRange(weapon);
    }

    public IEnumerable<TWeapon> Get() => _weapons;

    public TWeapon? GetById(Guid id) => _weapons.FirstOrDefault(weapon => weapon.Id == id);

    public DamageModel GetWeaponDamageById(Guid id) => _weapons.Where(weapon => weapon.Id == id).Select(weapon =>
    {
        if (weapon.CalculateIfCrit())
        {
            return new DamageModel(weapon.DealDamage() * weapon.CritPercentageDamage, weapon.CritEffect(), true);
        }
        return new DamageModel(weapon.DealDamage(), "Normal Damage Dealt", false);
    }).First();

    public void PatchWeapon(Guid id, string newName)
    {
        var item = _weapons.First(weapon => weapon.Id == id);
        item.Name = newName;
    }
}

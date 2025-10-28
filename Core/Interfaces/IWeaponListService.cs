using System;
using Core.Models;

namespace Core.Interfaces;

public interface IWeaponListService<TWeapon> where TWeapon : IWeapon
{
    public IEnumerable<TWeapon> Get();

    public TWeapon? GetById(Guid id);

    public DamageModel GetWeaponDamageById(Guid id);

    public void AddWeapon(TWeapon weapon);

    public void PatchWeapon(Guid id, string newName);

    public void DeleteWeapon(Guid id);
}

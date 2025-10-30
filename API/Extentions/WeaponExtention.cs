using System;
using Core.Models;

namespace API.Extensions;

public static class WeaponService
{
    public static bool CalculateIfCrit(this BaseWeaponCLR weapon) => Random.Shared.NextDouble() < weapon.CritPercentageChange;

    public static double CalculateDamage(this BaseWeaponCLR weapon) => weapon.BaseDamage * weapon.DamageModifier;

    public static DamageModel DealDamage(this BaseWeaponCLR weapon) => CalculateIfCrit(weapon) ? new DamageModel(CalculateDamage(weapon) * weapon.CritPercentageDamage, weapon.CritMessage, true) : new DamageModel(CalculateDamage(weapon), "Normal Damage", false);

}

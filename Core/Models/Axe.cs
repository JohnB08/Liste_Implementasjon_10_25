using System;
using Core.Interfaces;

namespace Core.Models;

public class Axe : BaseWeapon
{
    public Axe(string? name, double damageModifier = 1.5, double critChance = 0.25)
    {
        if (!string.IsNullOrWhiteSpace(name))Name = name;
        DamageModifier = damageModifier;
        CritPercentageChance = critChance;
    }
    public override string CritEffect() => "HAHAHAHA!";
}
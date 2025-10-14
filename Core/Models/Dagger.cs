using System;
using Core.Interfaces;

namespace Core.Models;

public class Dagger : BaseWeapon
{
    public new int CritPercentageChance => 25;

    public new int CritPercentageDamage => 110;
}
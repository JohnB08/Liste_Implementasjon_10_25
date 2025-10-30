using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Models;

public class BaseWeaponCLR
{
    [Key]
    public Guid Id { get; set; }

    public string Type { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public int BaseDamage { get; set; } = 100;

    public int DexReq { get; set; } = 10;

    public double DamageModifier { get; set; } = 1;

    public int StrenghtReq { get; set; } = 10;

    public double Shinyness { get; set; } = 0.90;

    public double ChanceOfFlisFromWoodShaft { get; set; } = 0.05;

    public double CritPercentageDamage { get; set; } = 2;

    public double CritPercentageChange { get; set; } = 0.10;

    public string CritMessage { get; set; } = "You crit!";
}

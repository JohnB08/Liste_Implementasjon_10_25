using Core.Interfaces;

namespace Core.Models;

public class BaseWeapon : IWeapon
{
    private string _name = "Unnamed Weapon";
    public string Name { get => _name; set => _name = _validateName(value); }
    /// <summary>
    /// The base damage of all weapons
    /// </summary>
    public int BaseDamage => 100;
    /// <summary>
    /// Base dex requirements for all weapons, defaults to 10
    /// </summary>
    private int _dexReq = 10;
    public int DexReq { get => _dexReq; set => _dexReq = Math.Abs(value); }
    /// <summary>
    /// Base damage modifier for all weapons, defaults to 1.
    /// </summary>
    private double _damageModifier = 1;
    public double DamageModifier { get => _damageModifier; set => _damageModifier = _validateValue(value, 1, 10); }

    /// <summary>
    /// Default strength requirements for all weapons, defaults to 10
    /// </summary>
    private int _strengthReq = 10;
    public int StrengthReq { get => _strengthReq; set => _strengthReq = Math.Abs(value); }

    /// <summary>
    /// Default shinyness of all weapons, defaults to 0.90 (represents percentage)
    /// </summary>
    private double _shinyness = 0.90;
    public double Shinyness { get => _shinyness; set => _shinyness = _validateValue(value); }

    /// <summary>
    /// Default chance to get a splinter from the wooden shaft, defaults to 0.05 (represents percentage)
    /// </summary>
    private double _chanceOfFlisFromWoodShaft = 0.05;
    public double ChanceOfFlisFromWoodShaft { get => _chanceOfFlisFromWoodShaft; set => _chanceOfFlisFromWoodShaft = _validateValue(value); }

    /// <summary>
    /// The message representing a crit effect.
    /// </summary>
    /// <returns></returns>
    public virtual string CritEffect() => "You crit!";


    /// <summary>
    /// Private method to validate an incoming value is within spesific boundaries.
    /// </summary>
    /// <param name="val"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    private double _validateValue(double val, double min = 0, double max = 1) => val < min || val > max ? throw new ArgumentOutOfRangeException(nameof(val)) : val;

    private string _validateName(string name) => string.IsNullOrWhiteSpace(name) ? throw new ArgumentNullException(nameof(name)) : name;

    /// <summary>
    /// The base method of dealing damage with a weapon
    /// </summary>
    /// <returns></returns>
    public virtual double DealDamage() => BaseDamage * DamageModifier;

    /// <summary>
    /// The damage modifier tied to a crit.
    /// </summary>
    private double _critPercentageDamage = 2;
    public double CritPercentageDamage { get => _critPercentageDamage; set => _critPercentageDamage = _validateValue(2, 10); }

    /// <summary>
    /// The base value representing chance of crit.
    /// </summary>
    private double _critPercentageChance = 0.10;
    public double CritPercentageChance { get => _critPercentageChance; set => _critPercentageChance = _validateValue(value); }

    /// <summary>
    /// The base method for calculating if a crit has happened. 
    /// </summary>
    /// <returns></returns>
    public virtual bool CalculateIfCrit() => Random.Shared.NextDouble() < CritPercentageChance;
}
namespace Core.Interfaces;
public interface IWeapon
{
    public string Name{ get; set; }
    public Guid Id { get; init; }
    public int DexReq { get; set; }
    public int StrengthReq { get; set; }

    public double Shinyness { get; set; }

    public double ChanceOfFlisFromWoodShaft { get; set; }

    public string CritEffect();

    public double CritPercentageChance { get; }
    
    public double CritPercentageDamage { get; }

    public bool CalculateIfCrit();

    public double DamageModifier { get; set; }

    public double DealDamage();
    
}
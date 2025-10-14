namespace Core.Interfaces;
public interface IWeapon
{
    public int DexReq { get; set; }
    public int StrengthReq { get; set; }

    public double Shinyness { get; set; }

    public double ChanceOfFlisFromWoodShaft { get; set; }

    public string CritEffect();

    public int CritPercentageChance { get; }
    
    public int CritPercentageDamage { get; }
    
}
using Core.Interfaces;

namespace Core.Models;

public class BaseWeapon : IWeapon
{
    public int DexReq { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int StrengthReq { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public double Shinyness { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public double ChanceOfFlisFromWoodShaft { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public virtual string CritEffect() => "You crit!";


    public int CritPercentageDamage => 100;

    public int CritPercentageChance => 10;
}
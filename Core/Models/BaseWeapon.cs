using Core.Interfaces;

namespace Core.Models;

public class BaseWeapon : IWeapon
{
    public int DexReq { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int StrengthReq { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public double Shinyness { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public double ChanceOfFlisFromWoodShaft { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}
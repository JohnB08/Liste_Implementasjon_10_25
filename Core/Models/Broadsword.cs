using System;
using Core.Interfaces;

namespace Core.Models;

public class Broadsword : BaseWeapon
{
    /// <summary>
    /// Legg merke til at i disse klassene må vi bruke standard constructoren siden BaseWeapon ikke har en constructor knyttet til seg.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="damageModifier"></param>
    /// <param name="strengthReq"></param>
    /// <param name="dexReq"></param>
    public Broadsword(string? name, double damageModifier = 1.2, int strengthReq = 11, int dexReq = 9)
    {
        if (!string.IsNullOrWhiteSpace(name)) Name = name;
        DamageModifier = damageModifier;
        StrengthReq = strengthReq;
        DexReq = dexReq;
    }
}

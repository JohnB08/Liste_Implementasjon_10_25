namespace Core.Interfaces;

public interface IWeaponList<TWeapon> where TWeapon : IWeapon
{
    public TWeapon this[int index] { get; set; }

    public void InsertNewWeapon(TWeapon weapon);

    public TWeapon PopWeapon();

    public int Length { get; }

}
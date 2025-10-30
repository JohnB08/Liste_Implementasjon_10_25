using System;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Database;

public class WeaponListDatabase(DbContextOptions<WeaponListDatabase> options) : DbContext(options)
{
    public DbSet<BaseWeaponCLR> Weapons { get; set; }

    public async Task AddWeapon(string type, string name)
    {
        await Weapons.AddAsync(new BaseWeaponCLR { Name = name, Type = type });
        await SaveChangesAsync();
    }

    public async Task<IEnumerable<BaseWeaponCLR>> Get() =>await Weapons.AsNoTracking().ToListAsync();

    public async Task<BaseWeaponCLR?> GetWeaponById(Guid id) => await Weapons.FirstOrDefaultAsync(weapon => weapon.Id == id);

    public async Task DeleteWeaponById(Guid id)
    {
        var weaponToRemove = await GetWeaponById(id) ?? throw new NullReferenceException($"Missing weapon with id: {id}");
        Weapons.Remove(weaponToRemove);
        await SaveChangesAsync();
    }

    public async Task PatchWeaponById(Guid id, string newName)
    {
        var item = await GetWeaponById(id) ?? throw new NullReferenceException($"Missing weapon with id: {id}");
        item.Name = newName;
        await SaveChangesAsync();
    }
}

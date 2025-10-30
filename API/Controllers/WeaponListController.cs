using System.Threading.Tasks;
using API.Database;
using API.Extensions;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]/")]
[ApiController]
public class WeaponListController(WeaponListDatabase weaponList) : ControllerBase
{
    [HttpGet("")] //representerer at denne metoden skal matches mot en GET request til http://localhost:5070/api/weaponlist/
    public IActionResult Get() => Ok(weaponList.Get());

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id) => Ok(await weaponList.GetWeaponById(id));

    [HttpPost("")]
    public async Task<IActionResult> Post([FromQuery] string type, [FromQuery] string name)
    {
        var normalizedType = type.Trim().ToLower();
        await weaponList.AddWeapon(normalizedType, name);
        return Ok();
    }

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> Patch(Guid id, [FromQuery] string newName)
    {
        await weaponList.PatchWeaponById(id,newName);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await weaponList.DeleteWeaponById(id);
        return Ok();
    }

    [HttpGet("{id:guid}/damage")]
    public async  Task<IActionResult> GetDamageById(Guid id)
    {
        if (await weaponList.GetWeaponById(id) is not { } foundWeapon) return NotFound();
        return Ok(foundWeapon.DealDamage());
    }


    
}

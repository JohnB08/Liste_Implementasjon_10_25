using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]/")]
[ApiController]
public class WeaponListController(IWeaponListService<IWeapon> weaponList) : ControllerBase
{
    [HttpGet("")] //representerer at denne metoden skal matches mot en GET request til http://localhost:5070/api/weaponlist/
    public IActionResult Get() => Ok(weaponList.Get());

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var potential = weaponList.GetById(id);
        if (potential is { } found) return Ok(found);
        return NotFound();
    }

    [HttpPost("")]
    public IActionResult Post([FromQuery] string type, [FromQuery] string name)
    {
        var normalizedType = type.Trim().ToLower();
        IWeapon? newWeapon = normalizedType switch
        {
            "axe" => new Axe(name),
            "broadsword" => new Broadsword(name),
            "greathammer" => new GreatHammer(name),
            _ => default,
        };
        if (newWeapon is null) return BadRequest();
        weaponList.AddWeapon(newWeapon);
        return Created(nameof(weaponList), newWeapon);
    }

    [HttpPatch("{id:guid}")]
    public IActionResult Patch(Guid id, [FromQuery] string newName)
    {
        if (weaponList.GetById(id) is null) return NotFound();
        weaponList.PatchWeapon(id, newName);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        if (weaponList.GetById(id) is null) return NotFound();
        weaponList.DeleteWeapon(id);
        return Ok();
    }

    [HttpGet("{id:guid}/damage")]
    public IActionResult GetDamageById(Guid id)
    {
        if (weaponList.GetById(id) is null) return NotFound();
        return Ok(weaponList.GetWeaponDamageById(id));
    }


    
}

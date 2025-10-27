using Core.Interfaces;
using Core.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

var weaponList = new WeaponList<IWeapon>();

//Vi kan mappe en funksjon til en resurs, og http metode.
app.MapGet(/* Resurser funksjonen blir mappet til */"/weatherforecast",/* Funksjonen som blir mappet */ () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");


//Read
app.MapGet("/weapons", () => weaponList);

app.MapGet("/weapons/{id:guid}", (Guid id) =>
{
    var foundWeapon = weaponList.FirstOrDefault(weapon => weapon.Id == id);
    return foundWeapon is { } weapon ? Results.Ok(weapon) : Results.NotFound();
});

app.MapGet("/weapons/{id:guid}/damage", (Guid id) =>
{
    var foundWeapon = weaponList.FirstOrDefault(weapon => weapon.Id == id);
    if (foundWeapon is null) return Results.NotFound();
    return foundWeapon.CalculateIfCrit() ? Results.Ok(new DamageEffect(foundWeapon.DealDamage() * foundWeapon.CritPercentageDamage, foundWeapon.CritEffect(), true)) : Results.Ok(new DamageEffect(foundWeapon.DealDamage(), "Normal damage.", false));
});

//Create
app.MapPost("/weapons/{weaponType}", (string weaponType, string weaponName) =>
{
    var normalisedWeaponType = weaponType.Trim().ToLower();
    switch (normalisedWeaponType)
    {
        case "axe":
            weaponList.InsertNewWeapon(new Axe(weaponName));
            return Results.Created();
        case "broadsword":
            weaponList.InsertNewWeapon(new Broadsword(weaponName));
            return Results.Created();
        case "greathammer":
            weaponList.InsertNewWeapon(new GreatHammer(weaponName));
            return Results.Created();
        default:
            return Results.BadRequest();
    }
});

//Update
app.MapPatch("/weapons/{id:guid}", (Guid id, string newName) =>
{
    var found = weaponList.FirstOrDefault(weapon => weapon.Id == id);
    if (found is null) return Results.NotFound();
    found.Name = newName;
    return Results.Ok();
});

//Delete

app.MapDelete("weapons/{id:guid}", (Guid id) =>
{
    var weapon = weaponList.FirstOrDefault(weapon => weapon.Id == id);
    if (weapon is null) return Results.NotFound();
    weaponList.RemoveRange(weapon);
    return Results.Ok();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

record DamageEffect(double Damage, string Message, bool Crit);
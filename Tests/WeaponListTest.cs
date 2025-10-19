using System;
using Core.Models;

namespace Tests;

public class WeaponListTest
{
    //Arrange
    //Act
    //Assert 
    [Fact]
    public void TestCanCreateListsOfWeapon()
    {
        //Arrange
        //Act
        var list = new WeaponList<Longsword>();

        //Assert
        Assert.NotNull(list);
    }

    [Fact]
    public void TestListWillGrow_IncreasedSizeMatchesGrowthFactor()
    {

        //Arrange
        var list = new WeaponList<Longsword>(capacity: 0, growthFactor: 1);


        var weapon = new Longsword();

        //Act
        list.InsertNewWeapon(weapon);


        //Assert
        Assert.Equal(1, list.Length);
    }

    [Fact]
    public void TestPoppingWeapons_StepsBackCorrectly()
    {
        //Arrange
        var list = new WeaponList<Longsword>(capacity: 0, growthFactor: 1);


        var weapon = new Longsword();

        list.InsertNewWeapon(weapon);

        //act
        var foundWeapon = list.PopWeapon();

        Assert.NotNull(foundWeapon);

        Assert.Equal(1, list.Length);

    }

    [Fact]
    public void TryCreatingList_ShouldLoopThroughOnlyValidItems()
    {
        //Arrange
        var list = new WeaponList<UltraGreatSword>();

        var weapon = new UltraGreatSword();

        list.InsertNewWeapon(weapon);

        //Act
        for (int i = 0; i < list.Length; i++)
        {
            Console.WriteLine(list[i].Length);
        }
        Assert.Throws<IndexOutOfRangeException>(() => Console.WriteLine(list[10].Length));
    }

    [Fact]
    public void TryInsertingIntoListAtSpesificIndexes()
    {
        //Arrange
        var list = new WeaponList<UltraGreatSword>();

        var weapon = new UltraGreatSword();

        list.InsertNewWeapon(weapon);

        Assert.Throws<IndexOutOfRangeException>(() => list[10] = new UltraGreatSword());

    }

    [Fact]
    public void FilterThroughAndSelectWeaponBasedOnProperty()
    {
        var list = new WeaponList<Axe>();
        var weapon = new Axe("WoodSplitter");

        list.InsertNewWeapon(weapon);



        //Siden listen vår nå implementerer IEnumerable kan vi plutselig få tilgang til hele LinQ apiet på vår datatype. 
        var found = list.FirstOrDefault(axe => axe.Name == "WoodSplitter");

        Assert.NotNull(found);
    }
}

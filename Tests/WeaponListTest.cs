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
    

}

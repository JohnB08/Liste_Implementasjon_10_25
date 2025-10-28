using System;
using System.Collections;
using Core.Interfaces;

namespace Core.Models;

/* Vårt mål på torsdag er å implementere en listetype vi kaller WeaponList som tar inn, og jobber med typen TWeapon. */
public class WeaponList<TWeapon>(int capacity = 0, int growthFactor = 1):IEnumerable<TWeapon>, IWeaponList<TWeapon> where TWeapon : IWeapon
    {
    /* Her skal vi sette opp måter å lagre store mengder av TWeapons typen, samt måter å behandle de på. */
    private TWeapon[] _data = new TWeapon[capacity];

    public int Length => _data.Length;

    /// <summary>
    /// Vi trenger en måte å holde oversikt over neste ledige plass i arrayet vårt,
    /// hvor vi kan adde et nytt våpen uten å overskrive et gammelt, det gjør vi via denne integeren.
    /// </summary>
    private int _indexOfSpareSpaceInData;

    /// <summary>
    /// Vi trenger en måte for oss å holde oversikt over Capasitien til vårt interne _data sett på en enkel måte.
    /// </summary>
    private int _capacity = capacity;

    /// <summary>
    /// Vår growthfactor er hvor mye det interne _data arrayet skal vokse hver gang det må vokse. 
    /// </summary>
    private int _growthFactor = growthFactor;

    /// <summary>
    /// Dette er en intern metode som vokser vårt interne array. Det overskriver det gamle eksisterende arrayet med et nytt array. 
    /// </summary>
    private void _growUnderlyingArray()
    {
        TWeapon[] newDataArray = new TWeapon[_capacity + _growthFactor];
        _data = [.. newDataArray.Select((_, index) => index < _capacity && _data[index] is not null ? _data[index] : default!)];
        _capacity = _data.Length;
    }


    /// <summary>
    /// Dette er en metode som inserter et nytt våpen i arrayet vårt, det vokser automatisk arrayet hvis
    /// det ikke er plass. 
    /// </summary>
    /// <param name="weapon">Våpenet som skal insertes. </param>
    public void InsertNewWeapon(TWeapon weapon)
    {
        if (_indexOfSpareSpaceInData >= _capacity)
        {
            _growUnderlyingArray();
        }
        _data[_indexOfSpareSpaceInData] = weapon;
        _indexOfSpareSpaceInData++;
    }

    /// <summary>
    /// En metode som "Popper" ut det siste arrayet i listen vår. 
    /// </summary>
    /// <returns></returns>
    public TWeapon PopWeapon()
    {
        //Legg merke til --_indexOfSpareSpaceInData, her tar vi et steg tilbake i arrayet vårt, og fjerner det våpenet. 
        //Vi dekrementer også index og sier den posisjonen er "ledig". 
        var weapon = _data[--_indexOfSpareSpaceInData];
        return weapon;
    }

    /// <summary>
    /// Her lager vi en enkel enumerator som yielder hvert item i _data arrayet vårt. 
    /// yield er et kult nøkkelord som lar oss returne ut fra en loop, men legge igjen en bookmark som sier hvor vi skal starte igjen neste gang metoden blir kallet. 
    /// </summary>
    /// <returns></returns>
    public IEnumerator<TWeapon> GetEnumerator()
    {
        foreach (var item in _data) yield return item;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    /// <summary>
    /// Her er en mer avansert måte å accesse det underliggende arrayet på. 
    /// this nøkkelordet refererer til objektet laget av blueprinten, og vi kan bruke this[in index] for å tillate array syntax også på vår datatype.
    /// Det vil si at hvis vi lager en WeaponList list, kan vi accesse første posisjon i denne listen via: list[0]. Handy!
    /// </summary>
    /// <param name="index">Dette er indexen i det underliggende arrayet vi prøver å eksponere ut for brukeren av datastrukturen vår. </param>
    /// <returns>Verdien i index.</returns>
    /// <exception cref="IndexOutOfRangeException"></exception>
    public TWeapon this[int index]
    {
        get
        {
            if (index >= _capacity) throw new IndexOutOfRangeException();
            return _data[index];
        }
        set => _data[index] = value;
    }
        
    public void RemoveRange(params TWeapon[] removeWeapon)
    {

        _data = [.. _data.Except(removeWeapon)];
    }
}

namespace Core.Models;

/* En generic class er en klasse som ikke vet hva datatype den skal jobbe med, før du faktisk lager et objekt med den. 
Legg merke til at den tar inn et parameter på en ny måte, via typeparameteret <TStored> TStored representerer datatypen StoredValue jobber med.  */
public class GenericEntity<TStored>
{
    /* Her ser du at vi par en Property StoredValue som jobber med / behandler den ukjente datatypen TStored. 
    Vår GenericEntity class vet ikke hva TStored er, før etter vi faktisk lager et objekt med klassen. Hvis du går inn i App prosjektet,
    vil du se at vi lager to forskjellige GenericEntity objekter der, en hvor TStored er int, og en hvor TStored er string. */
    public TStored StoredValue { get; set; }
}


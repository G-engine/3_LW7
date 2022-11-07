namespace library;

public enum eClassificationAnimal
{
    Herbivores,
    Carnivores,
    Omnivores
}

public enum eFavouriteFood
{
    Meat,
    Plants,
    Everything
}

[MyAttribute("base class for all animals")]
public class Animal
{
    public string Country { get; set; }
    public bool HideFromOtherAnimals { get; set; }
    public string Name { get; set; }
    public string WhatAnimal { get; set; }
    
    public Animal()
    {
        Country = "";
        Name = "";
        WhatAnimal = "";
        HideFromOtherAnimals = true;
    }
    public Animal(string country, string name, string whatAnimal, bool hideFromOtherAnimals)
    {
        Country = country;
        Name = name;
        WhatAnimal = whatAnimal;
        HideFromOtherAnimals = hideFromOtherAnimals;
    }

    public void Deconstruct()
    {
        
    }

    public eClassificationAnimal GetClassificationAnimal()
    {
        return eClassificationAnimal.Omnivores;
    }

    public virtual eFavouriteFood GetFavouriteFood()
    {
        return eFavouriteFood.Everything;
    }

    public virtual string SayHello()
    {
        return " ";
    }
}

[MyAttribute("cow is herbivorous animal")]
public class Cow : Animal
{
    public Cow(string country, string name, bool hideFromOtherAnimals) : base(country, name, "Cow",
        hideFromOtherAnimals) { }
    
    public override eFavouriteFood GetFavouriteFood()
    {
        return eFavouriteFood.Plants;
    }
    
    public override string SayHello()
    {
        return "Mooo";
    }
}

[MyAttribute("lion is carnivore animal")]
public class Lion : Animal
{
    public Lion(string country, string name, bool hideFromOtherAnimals) : base(country, name, "Lion",
        hideFromOtherAnimals) { }
    
    public override eFavouriteFood GetFavouriteFood()
    {
        return eFavouriteFood.Meat;
    }
    
    public override string SayHello()
    {
        return "Grrhrr";
    }
}

[MyAttribute("pig is herbivorous animal")]
public class Pig : Animal
{
    public Pig(string country, string name, bool hideFromOtherAnimals) : base(country, name, "Pig",
        hideFromOtherAnimals) { }

    public override eFavouriteFood GetFavouriteFood()
    {
        return eFavouriteFood.Plants;
    }

    public override string SayHello()
    {
        return "Hru";
    }
}
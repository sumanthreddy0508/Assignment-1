using System;

class VirtualPet
{
    public string Type { get; set; }
    public string Name { get; set; }
    private int hunger;
    private int happiness;
    private int health;

    public int Hunger
    {
        get { return hunger; }
        set { hunger = Math.Max(0, Math.Min(10, value)); }
    }

    public int Happiness
    {
        get { return happiness; }
        set { happiness = Math.Max(0, Math.Min(10, value)); }
    }

    public int Health
    {
        get { return health; }
        set { health = Math.Max(0, Math.Min(10, value)); }
    }

    public VirtualPet(string type, string name)
    {
        Type = type;
        Name = name;
        Hunger = 5;
        Happiness = 5;
        Health = 10; // Initial health is set to 10
    }

    public void Feed()
    {
        Hunger -= 2;
        Health += 1;
        Console.WriteLine($"{Name} has been fed. Hunger decreased by 2. Health increased by 1.");
        UpdateHealth();
    }

    public void Play()
    {
        Happiness += 2;
   
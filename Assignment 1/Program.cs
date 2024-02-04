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
        Hunger += 1;
        Console.WriteLine($"{Name} is happy! Happiness increased by 2. Hunger increased by 1.");
        UpdateHealth();
    }

    public void Rest()
    {
        Happiness -= 1;
        Health += 2;
        Console.WriteLine($"{Name} is resting. Happiness decreased by 1. Health increased by 2.");
        UpdateHealth();
    }

    private void UpdateHealth()
    {
        // Health is influenced by Hunger and Happiness
        Health = Math.Max(0, Math.Min(10, 10 - Hunger + Happiness));
    }

    public void CheckStatus()
    {
        Console.WriteLine($"{Name} the {Type}'s Stats:");
        Console.WriteLine($"Hunger: {Hunger} / 10");
        Console.WriteLine($"Happiness: {Happiness} / 10");
        Console.WriteLine($"Health: {Health} / 10");

        WarnIfCritical();
    }

    private void WarnIfCritical()
    {
        if (Hunger <= 2)
        {
            Console.WriteLine("Warning: Hunger is critically low!");
        }

        if (Happiness <= 2)
        {
            Console.WriteLine("Warning: Happiness is critically low!");
        }

        if (Health <= 2)
        {
            Console.WriteLine("Warning: Health is critically low!");
        }

        if (Hunger >= 8)
        {
            Console.WriteLine("Warning: Hunger is critically high!");
        }

        if (Happiness >= 8)
        {
            Console.WriteLine("Warning: Happiness is critically high!");
        }

        if (Health >= 8)
        {
            Console.WriteLine("Warning: Health is critically high!");
        }
    }

    public override bool Equals(object? obj)
    {
        return obj is VirtualPet pet &&
               Type == pet.Type &&
               Name == pet.Name &&
               hunger == pet.hunger &&
               happiness == pet.happiness &&
               health == pet.health &&
               Hunger == pet.Hunger &&
               Happiness == pet.Happiness &&
               Health == pet.Health;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Virtual Pet Simulator");
        Console.WriteLine("Choose a pet type:");
        Console.WriteLine("1. Cat");
        Console.WriteLine("2. Dog");
        Console.WriteLine("3. Rabbit");

        int petTypeChoice = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter a name for your pet:");
        string petName = Console.ReadLine();

        string petType;

        switch (petTypeChoice)
        {
            case 1:
                petType = "Cat";
                break;
            case 2:
                petType = "Dog";
                break;
            case 3:
                petType = "Rabbit";
                break;
            default:
                Console.WriteLine("Invalid choice. Exiting program.");
                return;
        }

        VirtualPet pet = new VirtualPet(petType, petName);

        Console.WriteLine($"Welcome to Virtual Pet Simulator!");
        Console.WriteLine($"You adopted {pet.Name} the {pet.Type}!");

        while (true)
        {

            Console.WriteLine("1. Feed");
            Console.WriteLine("2. Play");
            Console.WriteLine("3. Rest");
            Console.WriteLine("4. Check Status");
            Console.WriteLine("5. Quit");
            Console.WriteLine("\nChoose an action:");

            int action = int.Parse(Console.ReadLine());

            switch (action)
            {
                case 1:
                    pet.Feed();
                    break;
                case 2:
                    pet.Play();
                    break;
                case 3:
                    pet.Rest();
                    break;
                case 4:
                    pet.CheckStatus();
                    break;
                case 5:
                    Console.WriteLine("Exiting program. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}

   

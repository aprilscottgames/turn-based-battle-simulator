using System;

class Character
{
    public string Name;
    public int Health;
    public int AttackPower;
    public bool IsDefending;

    public Character(string name, int health, int attackPower)
    {
        Name = name;
        Health = health;
        AttackPower = attackPower;
        IsDefending = false;
    }

    public void Attack(Character target)
    {
        int damage = AttackPower;

        if (target.IsDefending)
        {
            damage /= 2;
        }

        target.Health -= damage;
        Console.WriteLine($"{Name} attacks {target.Name} for {damage} damage.");
    }

    public void Heal()
    {
        int healAmount = 10;
        Health += healAmount;
        Console.WriteLine($"{Name} heals for {healAmount} HP.");
    }

    public void Defend()
    {
        IsDefending = true;
        Console.WriteLine($"{Name} is defending and will take reduced damage.");
    }

    public void ResetTurn()
    {
        IsDefending = false;
    }

    public bool IsAlive()
    {
        return Health > 0;
    }
}

class Program
{
    static void Main()
    {
        Character player = new Character("Player", 50, 12);
        Character enemy = new Character("Enemy", 40, 10);
        Random random = new Random();

        Console.WriteLine("=== Turn-Based Battle Simulator ===\n");

        while (player.IsAlive() && enemy.IsAlive())
        {
            player.ResetTurn();
            enemy.ResetTurn();

            Console.WriteLine("------------------------");
            Console.WriteLine($"Player HP: {player.Health}");
            Console.WriteLine($"Enemy HP: {enemy.Health}");
            Console.WriteLine("------------------------");

            Console.WriteLine("Choose an action:");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Heal");
            Console.WriteLine("3. Defend");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    player.Attack(enemy);
                    break;
                case "2":
                    player.Heal();
                    break;
                case "3":
                    player.Defend();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            if (!enemy.IsAlive())
                break;

            Console.WriteLine("\nEnemy's turn:");

            int enemyChoice = random.Next(1, 4);

            if (enemyChoice == 1)
                enemy.Attack(player);
            else if (enemyChoice == 2)
                enemy.Heal();
            else
                enemy.Defend();

            Console.WriteLine();
        }

        Console.WriteLine(player.IsAlive() ? "You win!" : "You lost!");
    }
}

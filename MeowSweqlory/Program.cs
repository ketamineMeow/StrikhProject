using System;
class Program
{
    static string PlayerName = null;
    static bool HasKey = false;
    static bool HasPickLock = false;
    static bool[] artifactsFound = new bool[3]; // 0: Под кроватью, 1.Вентиляция, 2.Тумбочка 

    static void Main(string[] args)
    {
        StartGame();
    }

    static void StartGame()
    {
        Console.WriteLine(" Вас затащила в комнату злая бабуля, вы не помните как вас зовут и вы пытаетесь вспомнить своё имя ");
        Console.Write("Введите имя игрока: ");
        PlayerName = Console.ReadLine();
        Console.WriteLine($" Добро пожаловать, {PlayerName}!");

        while (true)
        {
            Console.WriteLine("\nДействия");
            Console.WriteLine("1: Открыть дверь");
            Console.WriteLine("2: Заглянуть под кровать");
            Console.WriteLine("3:Открыть ящик в углу комнаты");
            Console.WriteLine("4: Открыть вентиляцию");
            Console.WriteLine("5: Взглянуть на тумбочку");
            Console.WriteLine("6: Взглянуть на статую рядои с дверью");
            Console.WriteLine(" Выберите номер действия (или ‘Выход‘ для выхода):");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    OpenDoor();
                    break;
                case "2":
                    LookUnderBed();
                    break;
                case "3":
                    OpenBox();
                    break;
                case "4":
                    OpenVentilations();
                    break;
                case "6":
                    LookAtStatue();
                    break;
                case "5":
                    LookAtNightstand();
                    break;
                case "Выход":
                    Console.WriteLine("Вы выходите из игры.");
                    return;
                default:
                    Console.WriteLine("Неверный ввод. Попробуйте снова.");
                    break;

            }
        }
    }

    static void OpenDoor()
    {
        if (HasPickLock)
        {
            Console.WriteLine($" {PlayerName}, вам удалось сбежать от злой бабули!!");
            Environment.Exit(0);
        }
        else
        {
            Console.WriteLine($"{PlayerName}, не удается открыть дверь.Вам необходима отмычка!");
        }
    }
    static void LookUnderBed()
    {
        if (!artifactsFound[0])
        {
            artifactsFound[0] = true;
            Console.WriteLine($" {PlayerName}, под кроватью пусто");
        }
        else
        {
            Console.WriteLine($"{PlayerName},молодец, вы нашли первый артефакт.");
        }
    }

    static void OpenBox()
    {
        if (HasKey)
        {
            HasPickLock = true;
            Console.WriteLine($"{PlayerName}, ящик закрыт.Нужно активировать статую, чтобы получить ключ");
        }
        else
        {
            Console.WriteLine($"{PlayerName}, вам удалось открыть ящик, вы получили отмычку");
        }
    }
    static void OpenVentilations()
    {
        int attempts = 0;
        while (true)
        {
            if (artifactsFound[1])
            {
                Console.WriteLine($"{PlayerName},вы нашли артефакт");
                break;
            }

            Console.Write("Постарайтесь открыть вентиляцию..");
            string unput = Console.ReadLine();
            if (unput.ToLower() == "стоп")
            {
                break;
            }
            attempts++;

            if (attempts == 3)
            {
                artifactsFound[1] = true;
                Console.WriteLine($"{PlayerName}, вы нашли второй артефакт!");
                break;
            }
        }
    }
    static void LookAtNightstand()
    {
        if (artifactsFound[2])
        {
            artifactsFound[2] = true;
            Console.WriteLine($"{PlayerName}, умничка, третий артефакт найден");
        }
        else
        {
            Console.WriteLine($"{PlayerName},здесь ничего нет");
        }
    }

    static void LookAtStatue()
    {
        if (artifactsFound[0] && artifactsFound[1] && artifactsFound[2])
        {
            HasKey = true;
            Console.WriteLine($"{PlayerName},вам удалось активировать статую и вы получаете ключ!!!!!!");
        }
        else
        {
            Console.WriteLine($"{PlayerName},вам надо собрать три артефакта :(");
        }
    }
}

using System;
using System.Collections.Generic;

class Program
{
    static List<string> tasks = new List<string>();

    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("메뉴:");
            Console.WriteLine("1. 할 일 추가");
            Console.WriteLine("2. 할 일 목록 보기");
            Console.WriteLine("3. 할 일 삭제");
            Console.WriteLine("4. 계산기");
            Console.WriteLine("5. 종료");
            Console.Write("선택: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    DisplayTasks();
                    break;
                case "3":
                    RemoveTask();
                    break;
                case "4":
                    Calculator();
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    break;
            }
        }
    }

    static void AddTask()
    {
        Console.Write("할 일 입력: ");
        string task = Console.ReadLine();
        tasks.Add(task);
        Console.WriteLine("할 일이 추가되었습니다.");
    }

    static void RemoveTask()
    {
        DisplayTasks();
        Console.Write("삭제할 할 일 번호 입력: ");
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index >= 0 && index < tasks.Count)
        {
            tasks.RemoveAt(index);
            Console.WriteLine("할 일이 삭제되었습니다.");
        }
        else
        {
            Console.WriteLine("잘못된 번호입니다.");
        }
    }

    static void DisplayTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("할 일이 없습니다.");
        }
        else
        {
            Console.WriteLine("할 일 목록:");
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
        }
    }

    static void Calculator()
    {
        Console.Write("계산할 수식을 입력하세요 (예: 5 + 3): ");
        string input = Console.ReadLine();
        string[] parts = input.Split(' ');

        if (parts.Length != 3)
        {
            Console.WriteLine("올바른 형식이 아닙니다. 예시: 5 + 3");
            return;
        }

        int num1 = int.Parse(parts[0]);
        string op = parts[1];
        int num2 = int.Parse(parts[2]);
        int result = 0;

        switch (op)
        {
            case "+":
                result = num1 + num2;
                break;
            case "-":
                result = num1 - num2;
                break;
            case "*":
                result = num1 * num2;
                break;
            case "/":
                result = num1 / num2;
                break;
            default:
                Console.WriteLine("잘못된 연산자입니다.");
                return;
        }

        Console.WriteLine($"결과: {result}");;
    }
}

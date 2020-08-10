using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetBufferSize(120, 30);

            Walls walls = new Walls(120, 30);
            walls.Draw();

            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(119, 30, '$');
            Point food = foodCreator.CreateFood();
            Console.ForegroundColor = ConsoleColor.Red;
            food.Draw();
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            while (true)
            {
                if (walls.HasHit(snake) || snake.HasHitTail())
                    break;

                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    Console.ForegroundColor = ConsoleColor.Red;
                    food.Draw();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                else
                    snake.Move();

                Thread.Sleep(70);

                if (Console.KeyAvailable)
                    snake.HandleKey(Console.ReadKey().Key);
            }
            WriteGameOver();
            Console.ReadKey();
        }
        static void WriteGameOver()
        {
            int xOffset = 45;
            int yOffset = 10;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("============================", xOffset, yOffset++);
            WriteText("И Г Р А    О К О Н Ч Е Н А", xOffset + 1, yOffset++);
            yOffset++;
            WriteText("Автор: Лиза Бутырская", xOffset + 4, yOffset++);
            WriteText("============================", xOffset, yOffset++);
        }
        static void WriteText(String text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }
    }
}
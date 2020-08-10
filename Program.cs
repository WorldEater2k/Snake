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

            HorizontalLine upLine = new HorizontalLine(0, 118, 0, '\"');
            upLine.Draw();
            VerticalLine rightLine = new VerticalLine(0, 29, 118, '\"');
            rightLine.Draw();
            HorizontalLine downLine = new HorizontalLine(0, 118, 29, '\"');
            downLine.Draw();
            VerticalLine leftLine = new VerticalLine(0, 29, 0, '\"');
            leftLine.Draw();

            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();
            snake.Move();
            Thread.Sleep(1000);
            snake.Move();
            Thread.Sleep(1000);
            snake.Move();
            Thread.Sleep(1000);
            snake.Move();

            Console.ReadKey();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Point
    {
        private int x, y;
        private char sym;
        public Point(int x, int y, char sym)
        {
            this.x = x;
            this.y = y;
            this.sym = sym;
        }

        public Point (Point p)
        {
            x = p.x;
            y = p.y;
            sym = p.sym;
        }

        public void Move(int n, Direction direction)
        {
            if (direction == Direction.RIGHT)
                x += n;
            else if (direction == Direction.LEFT)
                x -= n;
            else if (direction == Direction.UP)
                y -= n;
            else
                y += n;
        }
        public bool HasHit(Point p)
        {
            return x == p.x && y == p.y;
        }
        public void Clear()
        {
            sym = ' ';
            Draw();
        }
        public int GetX()
        {
            return x;
        }
        public int GetY()
        {
            return y;
        }
        public char GetSym()
        {
            return sym;
        }
        public void SetX(int x)
        {
            this.x = x;
        }
        public void SetY(int y)
        {
            this.y = y;
        }
        public void SetSym(char sym)
        {
            this.sym = sym;
        }
        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }

        public override string ToString()
        {
            return x + ", " + y + ", " + sym;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake : Figure
    {
        private Direction direction;
        public Snake(Point tail, int length, Direction direction)
        {
            this.direction = direction;
            pList = new List<Point>();
            for (int i = 0; i < length; i++)
            {
                Point p = new Point(tail);
                p.Move(i, direction);
                pList.Add(p);
            }
        }
        public override void Draw()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            foreach (Point p in pList)
                p.Draw();
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void Move()
        {
            Point tail = pList.First();
            pList.Remove(tail);
            Point head = GetNextPoint();
            pList.Add(head);
            tail.Clear();
            head.Draw();
        }
        public Point GetNextPoint()
        {
            Point nextPoint = new Point(pList.Last());
            nextPoint.Move(1, direction);
            return nextPoint;
        }
        public bool HasHitTail()
        {
            var head = pList.Last();
            for (int i = 0; i < pList.Count - 2; i++)
            {
                if (head.HasHit(pList[i]))
                    return true;
            }
            return false;
        }
        public void HandleKey(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow)
                direction = Direction.LEFT;
            else if (key == ConsoleKey.RightArrow)
                direction = Direction.RIGHT;
            else if (key == ConsoleKey.UpArrow)
                direction = Direction.UP;
            else if (key == ConsoleKey.DownArrow)
                direction = Direction.DOWN;
        }
        public bool Eat(Point food)
        {
            Point head = GetNextPoint();
            if (head.HasHit(food))
            {
                food.SetSym(head.GetSym());
                pList.Add(food);
                return true;
            }
            else
                return false;
        }
    }
}

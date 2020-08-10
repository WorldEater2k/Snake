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

        public void Move()
        {
            Point tail = pList.First();
            pList.Remove(tail);
            Point head = this.GetNextPoint();
            pList.Add(head);
            tail.Clear();
            head.Draw();
        }
        public Point GetNextPoint()
        {
            Point nextPoint = new Point(pList.Last());
            nextPoint.Move(1, this.direction);
            return nextPoint;
        }
    }
}

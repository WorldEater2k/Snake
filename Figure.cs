using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    abstract class Figure
    {
        protected List<Point> pList;
        public virtual void Draw()
        {
            foreach (Point p in pList)
                p.Draw();
        }
        public bool HasHit(Figure figure)
        {
            foreach (var p in pList)
            {
                if (figure.HasHit(p))
                    return true;
            }
            return false;
        }

        public bool HasHit(Point point)
        {
            foreach (var p in pList)
            {
                if (p.HasHit(point))
                    return true;
            }
            return false;
        }
    }
}

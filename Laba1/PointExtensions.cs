using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Laba1
{
    public static class PointExtensions //векторные операции
    {
        public static PointF Add(this PointF a, PointF b) //добавление
        {
            return new PointF(a.X + b.X, a.Y + b.Y);
        }

        public static PointF Sub(this PointF a, PointF b) //разность
        {
            return new PointF(a.X - b.X, a.Y - b.Y); 
        }

        public static PointF Mul(this PointF a, float b)
        {
            return new PointF(a.X * b, a.Y * b);
        }

        public static float Dot(this PointF a, PointF b) //скалярное произведение
        {
            return a.X * b.X + a.Y * b.Y;
        }

        public static float Cross(this PointF a, PointF b)//пересечение
        {
            return a.X * b.Y - a.Y * b.X; 
        }
    }
}

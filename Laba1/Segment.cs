using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1
{
    public struct Segment //структура кот. содержит ребро, отрезок и операции с ним.
    {
        public readonly PointF A, B;

        public Segment(PointF a, PointF b)
        {
            A = a;
            B = b;
        }

        public bool OnLeft(PointF p) //совпадают ли знаки векторных произведений отдельных углов? (обходятся ли углы в одном направлении)
        {
            var ab = new PointF(B.X - A.X, B.Y - A.Y);
            var ap = new PointF(p.X - A.X, p.Y - A.Y);
            return ab.Cross(ap) >= 0;
        }

        public PointF Normal   //нормаль
        {
            get
            {
                return new PointF(B.Y - A.Y, A.X - B.X);
            }
        }

        public PointF Direction //направление
        {
            get
            {
                return new PointF(B.X - A.X, B.Y - A.Y);
            }
        }

        public float IntersectionParameter(Segment that) //вычисление параметра t для представления отрезка (ребра) в параметрическом виде (см. лекции)
        {
            var segment = this;
            var edge = that;

            var segmentToEdge = edge.A.Sub(segment.A);
            var segmentDir = segment.Direction;
            var edgeDir = edge.Direction;

            var t = edgeDir.Cross(segmentToEdge) / edgeDir.Cross(segmentDir);

            if (float.IsNaN(t)) //если не float-число
            {
                t = 0;
            }

            return t;
        }

        public Segment Morph(float tA, float tB) //отрезок полностью видим (внутри фигуры)
        {
            var d = Direction;
            return new Segment(A.Add(d.Mul(tA)), A.Add(d.Mul(tB)));
        }
    }
}

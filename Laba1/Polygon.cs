using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Laba1
{
    public class Polygon : List<PointF> //наследуемся от обобщенной коллекции List<T>, в нашем случае T = PointF (структура точки с плав. запятой на плоскости)
    {
        public Polygon()
            : base() // тут и далее base - ключевое слово, обозначающее конструктор базового класса
        { }
        
        public Polygon(int capacity)
            : base(capacity) //capacity - размер коллекции элементов List<PointF>
        { }

        public Polygon(IEnumerable<PointF> collection)
            : base(collection) //колекция элементов
        { }

        public bool IsConvex //проверка фигуры на выпуклость
        {
            get
            {
                if (Count >= 3) //если это замкнутая фигура (число точек >= 3)
                {
                    for (int a = Count - 2, b = Count - 1, c = 0; c < Count; a = b, b = c, ++c) //обходим углы
                    {
                        if (!new Segment(this[a], this[b]).OnLeft(this[c])) //если знаки векторных произведений для отдельных углов не совпадают
                        {
                            return false; //фигура не выпуклая
                        }
                    }
                }
                return true; //иначе - выпуклая
            }
        }

        public IEnumerable<Segment> Edges //генерация ребер (отрезков) из фигуры для перечисления через foreach
        {
            get
            {
                if (Count >= 2)
                {
                    for (int a = Count - 1, b = 0; b < Count; a = b, ++b)
                    {
                        yield return new Segment(this[a], this[b]);
                    }
                }
            }
        }

        private bool CyrusBeckClip(ref Segment subject) //действия выполняемы для отсекаемого отрезка
        {
            var subjDir = subject.Direction;
            var tA = 0.0f;
            var tB = 1.0f;
            foreach (var edge in Edges) //см. алгоритм https://ru.wikipedia.org/wiki/%D0%90%D0%BB%D0%B3%D0%BE%D1%80%D0%B8%D1%82%D0%BC_%D0%9A%D0%B8%D1%80%D1%83%D1%81%D0%B0_%E2%80%94_%D0%91%D0%B5%D0%BA%D0%B0
            {
                switch (Math.Sign(edge.Normal.Dot(subjDir))) //скалярное произведение вектора ребра и внешней нормали
                {
                    case -1: //отрезок направлен с внутренней на внешнюю сторону ребра (ребро тыльное)
                        {
                            var t = subject.IntersectionParameter(edge);
                            if (t > tA)
                            {
                                tA = t; //заменяем параметр
                            }
                            break;
                        }
                    case +1: //отрезок направлен с внешней на внутреннюю сторону ребра (ребро фронтальное)
                        {
                            var t = subject.IntersectionParameter(edge);
                            if (t < tB)
                            {
                                tB = t;
                            }
                            break;
                        }
                    case 0: //отрезок параллерен ребру
                        {
                            if (!edge.OnLeft(subject.A))
                            {
                                return false;
                            }
                            break;
                        }
                }
            }
            if (tA > tB) //если отрезок полностью невидим
            {
                return false;
            }
            subject = subject.Morph(tA, tB); //заданная параметрами tA и tB часть отрезка видима
            return true;
        }

        public List<Segment> CyrusBeckClip(List<Segment> subjects)
        {
            if (!IsConvex) //если многоугольник не выпуклый
            {
                Reverse(); //реверс элементов List<PointF>
                if (!IsConvex)
                {
                    MessageBox.Show("Отсекающий многоугольник должен быть выпуклым");
                    return subjects;
                    //throw new InvalidOperationException(""); //
                }
            }

            var clippedSubjects = new List<Segment>();
            foreach (var subject in subjects) //отсекаем все наши отрезки
            {
                var clippedSubject = subject;
                if (CyrusBeckClip(ref clippedSubject))
                {
                    clippedSubjects.Add(clippedSubject);
                }
            }
            return clippedSubjects;
        }
    }
}

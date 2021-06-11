using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsApp
{
    abstract class Shape : IDrawable
    {
        public abstract Graphics Distance { get; set; }

        public abstract Point[] Points { get; set; }

        public void Draw(params Point[] points)
        {
            foreach(Point p in points)
            {

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsApp
{
    interface IDrawable
    {
        void Draw(params Point[] points);
        
    }
}

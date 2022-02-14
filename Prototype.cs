using System;
using System.Collections.Generic;

namespace Patterns
{
    interface IArena
    {
        IArena Clone();
        void GetInfo();
    }

    class RecrangleArena : IArena
    {
        int width, height;

        public RecrangleArena(int w, int h)
        {
            width = w;
            height = h;
        }

        public IArena Clone()
        {
            return new RecrangleArena(this.width, this.height);
        }
        public void GetInfo()
        {
            Console.WriteLine($"Arena has width {width} m. and height {height} m.");
        }
    }
    class CircleArena : IArena
    {
        int radius;

        public CircleArena(int r)
        {
            radius = r;
        }

        public IArena Clone()
        {
            return new CircleArena(this.radius);
        }
        public void GetInfo()
        {
            Console.WriteLine($"Arena has radius {radius} m.");
        }
    }    
}
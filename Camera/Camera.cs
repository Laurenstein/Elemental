using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camera
{
    class Camera
    {


        int width, height;

        Vector2 absolutePosition = new Vector2(0, 0);

        public Vector2 position { get { return absolutePosition - new Vector2(width / 2, height / 2); }    }

        public Camera(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public void setPosition(Vector2 newAbsolute)
        {
            absolutePosition = newAbsolute;
        }
        
    }
        
    
}

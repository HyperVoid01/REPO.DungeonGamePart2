using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Game
{
    // Stores X & Y coordinates of single tiles
    public class Position
    {
        private int xPosition;
        private int yPosition;

        public Position(int x,int y)
        {
            this.xPosition = x;
            this.yPosition = y;
        }
        public int XPosition
        {
            get { return xPosition; }
            set { xPosition = value; }
        }

        public int YPosition
        {
            get { return yPosition; }
            set { yPosition = value; }
        }
    }
}

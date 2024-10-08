using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Game
{
    // Base class for child classes, no instances therefore abstract
    public abstract class Tile
    {
        private Position position;

        public Tile(Position position)
        {
            this.position = position;
        }

        // Properties for coordinates of tile
        public int XPosition
        {
            get { return position.XPosition; }
        }

        public int YPosition
        {
            get { return position.YPosition; }
        }

        public Position Position // Accessor
        {
            get { return position; }
            set { position = value; }
        }

        public abstract char Display // Overridden by child classes to visually represent each tile
        {
            get;
        }
    }
}

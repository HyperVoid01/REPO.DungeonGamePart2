using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Game
{
    // Tiles without walls / available tiles
    public class EmptyTile : Tile
    {
        private Position positions;
        public EmptyTile (Position positions) : base(positions)
        {
            this.positions = positions;
        }

        public override char Display
        {
            get { return '.'; }
        }
    }
}

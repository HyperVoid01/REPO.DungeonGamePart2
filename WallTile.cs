using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Game
{
    public class WallTile : Tile
    {
        public WallTile(Position position) : base(position)
        {
            
        }

        public override char Display // Visually represents walls
        {
            get { return '█'; }
        }
    }
}

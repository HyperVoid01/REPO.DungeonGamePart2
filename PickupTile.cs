using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Game
{
    public abstract class PickupTile : Tile
    {
        public PickupTile(Position position) : base(position)
        {

        }

        public abstract void ApplyEffect(CharacterTile target);
    }
}
